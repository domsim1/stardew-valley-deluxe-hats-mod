using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class LuckyBow
    {
        public const string Name = "Lucky Bow";
        public const string Description = "Gain Lucky charm Buff:\n+1 Luck";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff luckBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
                if (luckBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.LuckLevel.Set(1);
                    luckBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Lucky charm",
                        effects: effects
                        );
                    luckBuff.description = "Lucky charm\n+1 Luck";
                    luckBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    Game1.player.applyBuff(luckBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff luckBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
            if (luckBuff != null)
            {
                luckBuff.millisecondsDuration = 0;
            }
        }
    }
}
