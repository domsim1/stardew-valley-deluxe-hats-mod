using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class WatermelonBand
    {
        public const string Name = "Watermelon Band";
        public const string Description = "Gain the Summer Refreshment Buff:\n+2 Foraging\n+1 Fishing";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff watermelonBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
                if (watermelonBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.ForagingLevel.Set(2);
                    effects.FishingLevel.Set(1);
                    watermelonBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Summer Refreshment",
                        effects: effects
                        );
                    watermelonBuff.description = "Summer Refreshment\n+2 Foraging\n+1 Fishing";
                    watermelonBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    Game1.player.applyBuff(watermelonBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff watermelonBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
            if (watermelonBuff != null)
            {
                watermelonBuff.millisecondsDuration = 0;
            }
        }
    }
}
