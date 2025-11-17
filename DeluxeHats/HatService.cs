using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace DeluxeHats
{
    public static class HatService
    {
        public static string BuffId = "6284";

        public static IMonitor Monitor;
        public static IModHelper Helper;
        public static StardewValley.Farmer CurrentPlayer;

        public delegate void OnUpdateTickedDelegate(UpdateTickedEventArgs e);
        public delegate void OnTimeChangedDelegate(TimeChangedEventArgs e);
        public delegate void OnInventoryChangedDelegate(InventoryChangedEventArgs e);
        public delegate void OnButtonPressedDelegate(ButtonPressedEventArgs e);
        public delegate void OnDayStartDelegate(DayStartedEventArgs e);
        public delegate void OnDayEndingDelegate(DayEndingEventArgs e);
        private delegate void DisableHatDelegate();

        private class PlayerHatState
        {
            public OnUpdateTickedDelegate OnUpdateTicked;
            public OnTimeChangedDelegate OnTimeChanged;
            public OnInventoryChangedDelegate OnInventoryChanged;
            public OnButtonPressedDelegate OnButtonPressed;
            public OnDayStartDelegate OnDayStarted;
            public OnDayEndingDelegate OnDayEnding;
            public DisableHatDelegate DisableHat;
        }

        private static Dictionary<long, PlayerHatState> playerStates = new Dictionary<long, PlayerHatState>();
        private static HashSet<long> hookedPlayers = new HashSet<long>();

        public static OnUpdateTickedDelegate OnUpdateTicked
        {
            get => GetCurrentPlayerState()?.OnUpdateTicked;
            set => GetOrCreateCurrentPlayerState().OnUpdateTicked = value;
        }

        public static OnTimeChangedDelegate OnTimeChanged
        {
            get => GetCurrentPlayerState()?.OnTimeChanged;
            set => GetOrCreateCurrentPlayerState().OnTimeChanged = value;
        }

        public static OnInventoryChangedDelegate OnInventoryChanged
        {
            get => GetCurrentPlayerState()?.OnInventoryChanged;
            set => GetOrCreateCurrentPlayerState().OnInventoryChanged = value;
        }

        public static OnButtonPressedDelegate OnButtonPressed
        {
            get => GetCurrentPlayerState()?.OnButtonPressed;
            set => GetOrCreateCurrentPlayerState().OnButtonPressed = value;
        }

        public static OnDayStartDelegate OnDayStarted
        {
            get => GetCurrentPlayerState()?.OnDayStarted;
            set => GetOrCreateCurrentPlayerState().OnDayStarted = value;
        }

        public static OnDayEndingDelegate OnDayEnding
        {
            get => GetCurrentPlayerState()?.OnDayEnding;
            set => GetOrCreateCurrentPlayerState().OnDayEnding = value;
        }

        private static PlayerHatState GetCurrentPlayerState()
        {
            if (CurrentPlayer == null) return null;
            playerStates.TryGetValue(CurrentPlayer.UniqueMultiplayerID, out var state);
            return state;
        }

        private static PlayerHatState GetOrCreateCurrentPlayerState()
        {
            if (CurrentPlayer == null) return new PlayerHatState();

            if (!playerStates.TryGetValue(CurrentPlayer.UniqueMultiplayerID, out var state))
            {
                state = new PlayerHatState();
                playerStates[CurrentPlayer.UniqueMultiplayerID] = state;
            }
            return state;
        }

        public static void CleanUp()
        {
            foreach (var state in playerStates.Values)
            {
                CurrentPlayer = null;
                state.DisableHat?.Invoke();
            }
            playerStates.Clear();
            hookedPlayers.Clear();
        }

        public static void SetupPlayerHatTracking()
        {
            foreach (var farmer in Game1.getAllFarmers())
            {
                if (!hookedPlayers.Contains(farmer.UniqueMultiplayerID))
                {
                    farmer.hat.fieldChangeEvent += (field, oldValue, newValue) => HatChanged(farmer);
                    hookedPlayers.Add(farmer.UniqueMultiplayerID);
                    ApplyHatEffect(farmer);
                }
            }
        }

        private static void CleanUpPlayer(StardewValley.Farmer player)
        {
            if (player == null) return;

            if (playerStates.TryGetValue(player.UniqueMultiplayerID, out var state))
            {
                state.DisableHat?.Invoke();
                playerStates.Remove(player.UniqueMultiplayerID);
            }
        }

        public static void UpdateTicked(object sender, UpdateTickedEventArgs e)
        {
            foreach (var farmer in Game1.getAllFarmers())
            {
                if (playerStates.TryGetValue(farmer.UniqueMultiplayerID, out var state))
                {
                    CurrentPlayer = farmer;
                    state.OnUpdateTicked?.Invoke(e);
                }
            }
            CurrentPlayer = null;
        }

        public static void TimeChanged(object sender, TimeChangedEventArgs e)
        {
            foreach (var farmer in Game1.getAllFarmers())
            {
                if (playerStates.TryGetValue(farmer.UniqueMultiplayerID, out var state))
                {
                    CurrentPlayer = farmer;
                    state.OnTimeChanged?.Invoke(e);
                }
            }
            CurrentPlayer = null;
        }

        public static void InventoryChanged(object sender, InventoryChangedEventArgs e)
        {
            if (e.IsLocalPlayer && playerStates.TryGetValue(e.Player.UniqueMultiplayerID, out var state))
            {
                CurrentPlayer = e.Player;
                state.OnInventoryChanged?.Invoke(e);
                CurrentPlayer = null;
            }
        }

        public static void ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            foreach (var farmer in Game1.getAllFarmers())
            {
                if (playerStates.TryGetValue(farmer.UniqueMultiplayerID, out var state))
                {
                    CurrentPlayer = farmer;
                    state.OnButtonPressed?.Invoke(e);
                }
            }
            CurrentPlayer = null;
        }

        public static void DayStarted(object sender, DayStartedEventArgs e)
        {
            foreach (var farmer in Game1.getAllFarmers())
            {
                CurrentPlayer = farmer;
                ApplyHatEffect(farmer);
                if (playerStates.TryGetValue(farmer.UniqueMultiplayerID, out var state))
                {
                    state.OnDayStarted?.Invoke(e);
                }
            }
            CurrentPlayer = null;
        }

        public static void DayEnding(object sender, DayEndingEventArgs e)
        {
            foreach (var farmer in Game1.getAllFarmers())
            {
                if (playerStates.TryGetValue(farmer.UniqueMultiplayerID, out var state))
                {
                    CurrentPlayer = farmer;
                    state.OnDayEnding?.Invoke(e);
                }
            }
            CurrentPlayer = null;
        }

        public static void HatChanged(StardewValley.Farmer player)
        {
            if (player != null)
            {
                ApplyHatEffect(player);
            }
        }

        private static void ApplyHatEffect(StardewValley.Farmer player)
        {
            if (player == null) return;

            CurrentPlayer = player;
            CleanUpPlayer(player);

            if (player.hat.Value != null)
            {
                string equippedHatName = player.hat.Value.Name;
                Monitor.Log($"Hat Equipped by {player.Name}: {equippedHatName}", LogLevel.Trace);

                Type hatType = typeof(HatService).Assembly.GetTypes()
                    .FirstOrDefault(t =>
                        t.Namespace == "DeluxeHats.Hats" &&
                        t.IsClass &&
                        t.GetField("Name", BindingFlags.Public | BindingFlags.Static)?.GetValue(null) as string == equippedHatName);

                if (hatType != null)
                {
                    var state = GetOrCreateCurrentPlayerState();

                    MethodInfo activateMethod = hatType.GetMethod("Activate", BindingFlags.Public | BindingFlags.Static);
                    activateMethod?.Invoke(null, null);

                    MethodInfo disableMethod = hatType.GetMethod("Disable", BindingFlags.Public | BindingFlags.Static);
                    if (disableMethod != null)
                    {
                        state.DisableHat = (DisableHatDelegate)Delegate.CreateDelegate(typeof(DisableHatDelegate), disableMethod);
                    }
                }
                else
                {
                    Monitor.Log($"Hat not found: {equippedHatName}", LogLevel.Warn);
                }
            }

            CurrentPlayer = null;
        }
    }
}
