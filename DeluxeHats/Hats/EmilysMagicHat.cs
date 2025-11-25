using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class EmilysMagicHat
    {
        public const string Name = "Emily's Magic Hat";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff emilyBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (emilyBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.LuckLevel.Set(3);
                    emilyBuff = new Buff(
                        id: HatService.BuffId,
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.emilys-magic-hat.name"),
                        displayName: HatService.GetTranslation("hat.emilys-magic-hat.buff.name"),
                        effects: effects
                        );
                    emilyBuff.description = HatService.GetTranslation("hat.emilys-magic-hat.buff.description");
                    emilyBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(emilyBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff emilyBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (emilyBuff != null)
            {
                emilyBuff.millisecondsDuration = 0;
            }
        }
    }
}
