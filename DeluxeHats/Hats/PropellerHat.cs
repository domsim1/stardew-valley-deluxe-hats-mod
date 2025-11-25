using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class PropellerHat
    {
        public const string Name = "Propeller Hat";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff propellerBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (propellerBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.Speed.Set(1);
                    propellerBuff = new Buff(
                        id: HatService.BuffId,
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.propeller-hat.name"),
                        displayName: HatService.GetTranslation("hat.propeller-hat.buff.name"),
                        effects: effects
                        );
                    propellerBuff.description = HatService.GetTranslation("hat.propeller-hat.buff.description");
                    propellerBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(propellerBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff propellerBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (propellerBuff != null)
            {
                propellerBuff.millisecondsDuration = 0;
            }
        }
    }
}
