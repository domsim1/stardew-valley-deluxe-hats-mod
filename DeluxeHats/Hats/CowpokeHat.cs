using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class CowpokeHat
    {
        public const string Name = "Cowpoke Hat";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff cowpokeBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (HatService.CurrentPlayer.isRidingHorse())
                {
                    if (cowpokeBuff == null)
                    {
                        var effects = new BuffEffects();
                        effects.Speed.Set(1);
                        cowpokeBuff = new Buff(
                            id: HatService.BuffId,
                            source: HatService.GetTranslation("mod.name"),
                            displaySource: HatService.GetTranslation("hat.cowpoke-hat.name"),
                            displayName: HatService.GetTranslation("hat.cowpoke-hat.buff.name"),
                            effects: effects
                            );
                        cowpokeBuff.description = HatService.GetTranslation("hat.cowpoke-hat.buff.description");
                        cowpokeBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                        HatService.CurrentPlayer.applyBuff(cowpokeBuff);
                    }
                }
                else
                {
                    if (cowpokeBuff != null)
                    {
                        cowpokeBuff.millisecondsDuration = 0;
                    }
                }
            };
        }

        public static void Disable()
        {
            Buff cowpokeBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (cowpokeBuff != null)
            {
                cowpokeBuff.millisecondsDuration = 0;
            }
        }
    }
}
