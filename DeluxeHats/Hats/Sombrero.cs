using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class Sombrero
    {
        public const string Name = "Sombrero";
        public const string Description = "Gain the Fiesta Buff:\n+2 Luck";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff sombruroBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
                if (sombruroBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.LuckLevel.Set(2);
                    sombruroBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Fiesta",
                        effects: effects
                        );
                    sombruroBuff.description = "Fiesta\n+2 Luck";
                    sombruroBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(sombruroBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff sombruroBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
            if (sombruroBuff != null)
            {
                sombruroBuff.millisecondsDuration = 0;
            }
        }
    }
}
