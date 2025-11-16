using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class WarriorHelmet
    {
        public const string Name = "Warrior Helmet";
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
