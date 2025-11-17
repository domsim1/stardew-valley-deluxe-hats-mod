using StardewValley;
using StardewValley.Characters;
using System;
using System.Collections.Generic;

namespace DeluxeHats.Hats
{
    public static class PumpkinMask
    {
        public const string Name = "Pumpkin Mask";
        public const string Description = "Spawn a horse and mount it.\nThe horse will disappear when you unmount it.";
        private static Dictionary<long, Horse> playerHorses = new Dictionary<long, Horse>();

        public static void Activate()
        {
            if (HatService.CurrentPlayer == null) return;

            if (!HatService.CurrentPlayer.currentLocation.isOutdoors.Value || Game1.eventUp)
            {
                return;
            }

            long playerId = HatService.CurrentPlayer.UniqueMultiplayerID;

            if (HatService.CurrentPlayer.isRidingHorse())
            {
                return;
            }

            if (!playerHorses.ContainsKey(playerId))
            {
                var horse = new Horse(new Guid(), (int)HatService.CurrentPlayer.Tile.X, (int)HatService.CurrentPlayer.Tile.Y)
                {
                    currentLocation = HatService.CurrentPlayer.currentLocation,
                };
                horse.faceDirection(HatService.CurrentPlayer.getDirection());
                horse.Name = "Daredevil" + HatService.CurrentPlayer.name.Value;
                horse.displayName = "Daredevil";
                HatService.CurrentPlayer.currentLocation.characters.Add((NPC)horse);
                horse.checkAction(HatService.CurrentPlayer, HatService.CurrentPlayer.currentLocation);
                playerHorses[playerId] = horse;
            }
        }

        public static void Disable()
        {
            if (HatService.CurrentPlayer == null) return;

            long playerId = HatService.CurrentPlayer.UniqueMultiplayerID;

            if (playerHorses.TryGetValue(playerId, out Horse horse))
            {
                playerHorses.Remove(playerId);

                if (HatService.CurrentPlayer.mount != null && HatService.CurrentPlayer.mount.Equals(horse))
                {
                    HatService.CurrentPlayer.mount = null;
                    HatService.CurrentPlayer.setMountedPosition(0, 0);
                }

                if (horse.currentLocation != null)
                {
                    horse.currentLocation.characters.Remove(horse);
                }
            }
        }
    }
}
