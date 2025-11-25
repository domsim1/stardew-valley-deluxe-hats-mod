using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class ChickenMask
    {
        public const string Name = "Chicken Mask";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff chickenBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (chickenBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.FarmingLevel.Set(2);
                    chickenBuff = new Buff(
                        id: HatService.BuffId,
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.chicken-mask.name"),
                        displayName: HatService.GetTranslation("hat.chicken-mask.buff.name"),
                        effects: effects
                        );
                    chickenBuff.description = HatService.GetTranslation("hat.chicken-mask.buff.description");
                    chickenBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(chickenBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff chickenBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (chickenBuff != null)
            {
                chickenBuff.millisecondsDuration = 0;
            }
        }
    }
}
