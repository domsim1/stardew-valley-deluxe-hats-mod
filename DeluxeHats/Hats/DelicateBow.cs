using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewValley;
using StardewValley.BellsAndWhistles;
using System;
using System.Collections.Generic;

namespace DeluxeHats.Hats
{
    public static class DelicateBow
    {
        public const string Name = "Delicate Bow";
        public const string Description = "Sparkles inside!\nPeople in the same inside area as you will gain 5 friendship every 7 seconds.";

        private static readonly IReflectedField<Multiplayer> multiplayer = HatService.Helper.Reflection.GetField<Multiplayer>(typeof(Game1), "multiplayer");
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                if (HatService.CurrentPlayer.currentLocation.isOutdoors.Value || HatService.CurrentPlayer.hasMenuOpen.Value || !HatService.CurrentPlayer.canMove || !Game1.game1.IsActive)
                {
                    return;
                }
                if (e.Ticks % 480 == 0)
                {
                    multiplayer.GetValue().broadcastSprites(HatService.CurrentPlayer.currentLocation, Utility.sparkleWithinArea(new Rectangle(Convert.ToInt32(HatService.CurrentPlayer.position.X), Convert.ToInt32(HatService.CurrentPlayer.position.Y) - 128, 32, 32), 2, Color.DeepPink));
                    foreach (var npc in HatService.CurrentPlayer.currentLocation.characters)
                    {
                        HatService.CurrentPlayer.changeFriendship(5, npc);
                    }
                }

            };
        }

        public static void Disable()
        {
        }
    }
}
