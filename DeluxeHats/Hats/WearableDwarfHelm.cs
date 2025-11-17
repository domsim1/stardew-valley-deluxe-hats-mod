using System.Collections.Generic;
using System.Linq;
using StardewValley;
using StardewValley.Locations;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class WearableDwarfHelm
    {
        public const string Name = "Wearable Dwarf Helm";
        public const string Description = "You can Understand Dwarves.\nWhen entering a new level of a mine gain Mad Dwarf King buff:\n+4 Mining\n+2 Speed\n+1 Attack.";
        private static Dictionary<long, string> playerLastLocation = new Dictionary<long, string>();

        public static void Activate()
        {
            if (HatService.CurrentPlayer == null) return;

            HatService.CurrentPlayer.canUnderstandDwarves = true;
            HatService.OnUpdateTicked = (e) =>
            {
                if (HatService.CurrentPlayer.hasMenuOpen.Value || !HatService.CurrentPlayer.canMove || !Game1.game1.IsActive || Game1.eventUp)
                {
                    return;
                }

                if (!HatService.CurrentPlayer.currentLocation.name.Value.Contains("UndergroundMine"))
                {
                    return;
                }

                long playerId = HatService.CurrentPlayer.UniqueMultiplayerID;
                string currentLocation = HatService.CurrentPlayer.currentLocation.name.Value;

                if (playerLastLocation.TryGetValue(playerId, out string lastLocation) && currentLocation == lastLocation)
                {
                    return;
                }

                playerLastLocation[playerId] = currentLocation;

                Buff dwarfBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (dwarfBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.MiningLevel.Set(4);
                    effects.Speed.Set(2);
                    effects.Attack.Set(1);
                    dwarfBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Mad Dwarf King",
                        effects: effects
                        );
                    dwarfBuff.description = "Mad Dwarf King\n+4 Mining\n+2 Speed\n+1 Attack";
                    HatService.CurrentPlayer.applyBuff(dwarfBuff);
                }
                dwarfBuff.millisecondsDuration = 21510;
            };
        }

        public static void Disable()
        {
            if (HatService.CurrentPlayer == null) return;

            long playerId = HatService.CurrentPlayer.UniqueMultiplayerID;
            playerLastLocation.Remove(playerId);

            var mus = (LibraryMuseum)Game1.getLocationFromName("ArchaeologyHouse");
            if (mus != null)
            {
                var museumItems = new HashSet<int>(mus.museumPieces.Values.Select(s => int.TryParse(s, out var id) ? id : -1));
                if (museumItems.Contains(96) && museumItems.Contains(97) && museumItems.Contains(98) && museumItems.Contains(99))
                {
                    HatService.CurrentPlayer.canUnderstandDwarves = true;
                }
                else
                {
                    HatService.CurrentPlayer.canUnderstandDwarves = false;
                }
            }

            Buff dwarfBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (dwarfBuff != null)
            {
                dwarfBuff.millisecondsDuration = 0;
            }
        }
    }
}
