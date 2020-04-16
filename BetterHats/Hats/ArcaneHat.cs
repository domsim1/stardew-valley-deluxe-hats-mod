using StardewValley;
using System;

namespace BetterHats.Hats
{
    public static class ArcaneHat
    {
        public const string Name = "Arcane Hat";
        private const double arcaneSetbackTimerChance = 0.0008f;
        public static void Activate()
        {
            HatService.OnTickMethod = (e) =>
            {
                if (Game1.random.NextDouble() < (arcaneSetbackTimerChance + (Game1.player.DailyLuck / 2000.0)))
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
