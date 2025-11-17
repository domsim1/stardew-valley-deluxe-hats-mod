using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class FlatToppedHat
    {
        public const string Name = "Flat Topped Hat";
        public const string Description = "Gain the Noble Buff:\n+1 Defense\n+1 Luck";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff flatBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
                if (flatBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.Defense.Set(1);
                    effects.LuckLevel.Set(1);
                    flatBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Noble",
                        effects: effects
                        );
                    flatBuff.description = "Noble\n+1 Defense\n+1 Luck";
                    flatBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(flatBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff flatBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
            if (flatBuff != null)
            {
                flatBuff.millisecondsDuration = 0;
            }
        }
    }
}
