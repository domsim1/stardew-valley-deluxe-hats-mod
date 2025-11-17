using StardewValley;
using StardewValley.Characters;
using System;

namespace DeluxeHats.Hats
{
    public static class PumpkinMask
    {
        public const string Name = "Pumpkin Mask";
        public const string Description = "Spawn a horse and mount it.\nThe horse will disappear when you unmount it.";
        private static Horse daredevil;
        public static void Activate()
        {
            if (!Game1.currentLocation.isOutdoors.Value || Game1.eventUp)
            {
                return;
            }
            if (daredevil == null)
            {
                daredevil = new Horse(new Guid(), (int)HatService.CurrentPlayer.Tile.X, (int)HatService.CurrentPlayer.Tile.Y)
                {
                    currentLocation = Game1.currentLocation,
                };
                daredevil.faceDirection(HatService.CurrentPlayer.getDirection());
                daredevil.Name = "Daredevil";
                daredevil.displayName = "Daredevil";
                Game1.getFarm().characters.Add((NPC)daredevil);
                daredevil.checkAction(HatService.CurrentPlayer, Game1.currentLocation);
            }
        }

        public static void Disable()
        {
            if (daredevil != null) {
                daredevil.checkAction(HatService.CurrentPlayer, Game1.currentLocation);
            }
            Game1.getFarm().characters.Remove(daredevil);
            daredevil = null;
        }
    }
}
