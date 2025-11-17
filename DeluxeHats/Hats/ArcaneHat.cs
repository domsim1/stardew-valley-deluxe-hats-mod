using StardewValley;

namespace DeluxeHats.Hats
{
    public static class ArcaneHat
    {
        public const string Name = "Arcane Hat";
        public const string Description = "Random chance to delay time.";
        private const double arcaneSetbackTimerChance = 0.0008f;
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                if (HatService.CurrentPlayer.hasMenuOpen.Value || !HatService.CurrentPlayer.canMove || !Game1.game1.IsActive)
                {
                    return;
                }
                if (Game1.random.NextDouble() < (arcaneSetbackTimerChance + (HatService.CurrentPlayer.DailyLuck / 2000.0)))
                {
                    Game1.gameTimeInterval = 0;
                }
            };
        }

        public static void Disable()
        {
        }
    }
}
