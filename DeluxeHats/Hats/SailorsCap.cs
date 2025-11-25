using System.Linq;
using Microsoft.Xna.Framework;
using StardewValley;
using StardewValley.Buffs;
using System.Collections.Generic;

namespace DeluxeHats.Hats
{
    public static class SailorsCap
    {
        public const string Name = "Sailor's Cap";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff tipsyBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.displayName == "Tipsy");
                if (tipsyBuff != null)
                {
                    Buff powerBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                    if (powerBuff == null)
                    {
                        var effects = new BuffEffects();
                        effects.Attack.Set(10);
                        powerBuff = new Buff(
                            id: HatService.BuffId,
                            source: HatService.GetTranslation("mod.name"),
                            displaySource: HatService.GetTranslation("hat.sailors-cap.name"),
                            displayName: HatService.GetTranslation("hat.sailors-cap.buff.name"),
                            effects: effects
                            );
                        powerBuff.description = HatService.GetTranslation("hat.sailors-cap.buff.description");
                        powerBuff.millisecondsDuration = tipsyBuff.millisecondsDuration;
                        HatService.CurrentPlayer.applyBuff(powerBuff);
                        HatService.CurrentPlayer.startGlowing(Color.OrangeRed * 0.5f, false, 0.08f);
                    }   
                    powerBuff.millisecondsDuration = tipsyBuff.millisecondsDuration;
                }
                else if (HatService.CurrentPlayer.isGlowing && HatService.CurrentPlayer.glowingColor == Color.OrangeRed * 0.5f)
                {
                    HatService.CurrentPlayer.stopGlowing();
                }
            };
        }

        public static void Disable()
        {
            Buff powerBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (powerBuff != null)
            {
                powerBuff.millisecondsDuration = 0;
            }
        }
    }
}
