using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class Sunglasses
    {
        public const string Name = "Sunglasses";
        public const string Description = "No effect.";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                // No effect
            };
        }

        public static void Disable()
        {
            // No effect
        }
    }
}
