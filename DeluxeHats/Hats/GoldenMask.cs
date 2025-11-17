using Microsoft.Xna.Framework;
using StardewValley;
using System;

namespace DeluxeHats.Hats
{
    public static class GoldenMask
    {
        public const string Name = "Golden Mask";
        public const string Description = "Damage enemies near you every 3 seconds, the damage can kill mummies.";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                if (HatService.CurrentPlayer.hasMenuOpen.Value || !HatService.CurrentPlayer.canMove || !Game1.game1.IsActive)
                {
                    return;
                }
                if (e.IsMultipleOf(180))
                {
                    var rect = new Rectangle(
                        x: Convert.ToInt32(HatService.CurrentPlayer.position.X - 320),
                        y: Convert.ToInt32(HatService.CurrentPlayer.position.Y - 320),
                        width: 640,
                        height: 640);
                    Game1.currentLocation.damageMonster(rect, 1, 20, true, HatService.CurrentPlayer);
                }
            };
        }

        public static void Disable()
        {
        }
    }
}
