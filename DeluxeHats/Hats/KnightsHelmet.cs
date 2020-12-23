using StardewValley;

namespace DeluxeHats.Hats
{
    public static class KnightsHelmet
    {
        public const string Name = "Knight's Helmet";
        public const string Description = "Gain +4 armour and +2 resistance.";
        private const int knightsResilience = 4;
        private const int kightsImmunity = 2;
        public static void Activate()
        {
            Game1.player.resilience += knightsResilience;
            Game1.player.immunity += kightsImmunity;
        }

        public static void Disable()
        {
            Game1.player.resilience -= knightsResilience;
            Game1.player.immunity -= kightsImmunity;
        }
    }
}
