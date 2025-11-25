using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class WatermelonBand
    {
        public const string Name = "Watermelon Band";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff watermelonBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (watermelonBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.ForagingLevel.Set(2);
                    effects.FishingLevel.Set(1);
                    watermelonBuff = new Buff(
                        id: HatService.BuffId,
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.watermelon-band.name"),
                        displayName: HatService.GetTranslation("hat.watermelon-band.buff.name"),
                        effects: effects
                        );
                    watermelonBuff.description = HatService.GetTranslation("hat.watermelon-band.buff.description");
                    watermelonBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(watermelonBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff watermelonBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (watermelonBuff != null)
            {
                watermelonBuff.millisecondsDuration = 0;
            }
        }
    }
}
