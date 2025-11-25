using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class LivingHat
    {
        public const string Name = "Living Hat";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff livingBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (livingBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.FarmingLevel.Set(2);
                    livingBuff = new Buff(
                        id: HatService.BuffId,
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.living-hat.name"),
                        displayName: HatService.GetTranslation("hat.living-hat.buff.name"),
                        effects: effects
                        );
                    livingBuff.description = HatService.GetTranslation("hat.living-hat.buff.description");
                    livingBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(livingBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff livingBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (livingBuff != null)
            {
                livingBuff.millisecondsDuration = 0;
            }
        }
    }
}
