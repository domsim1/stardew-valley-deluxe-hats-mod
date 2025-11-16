using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class ChickenMask
    {
        public const string Name = "Chicken Mask";
        public const string Description = "Gain the Chicken Friend Buff:\n+2 Farming";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff chickenBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
                if (chickenBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.FarmingLevel.Set(2);
                    chickenBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Chicken Friend",
                        effects: effects
                        );
                    chickenBuff.description = "Chicken Friend\n+2 Farming";
                    chickenBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    Game1.player.applyBuff(chickenBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff chickenBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
            if (chickenBuff != null)
            {
                chickenBuff.millisecondsDuration = 0;
            }
        }
    }
}
