using StardewValley;
using StardewValley.Buffs;
using System;
using System.Linq;

namespace DeluxeHats.Hats
{
    public static class BlueCowboyHat
    {
        public const string Name = "Blue Cowboy Hat";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff horseBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (HatService.CurrentPlayer.isRidingHorse())
                {
                    if (horseBuff == null)
                    {
                        var effects = new BuffEffects();
                        effects.Speed.Set(2);
                        horseBuff = new Buff(
                            id: HatService.BuffId,
                            source: HatService.GetTranslation("mod.name"),
                            displaySource: HatService.GetTranslation("hat.blue-cowboy-hat.name"),
                            displayName: HatService.GetTranslation("hat.blue-cowboy-hat.buff.name"),
                            effects: effects
                            );
                        horseBuff.description = HatService.GetTranslation("hat.blue-cowboy-hat.buff.description");
                        horseBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                        HatService.CurrentPlayer.applyBuff(horseBuff);
                    }
                    if (horseBuff.millisecondsDuration < 30001)
                    {
                        horseBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    }
                }
                else
                {
                    if (horseBuff != null && horseBuff.millisecondsDuration > 30001)
                    {
                        horseBuff.millisecondsDuration = 30000;
                    }
                }
            };
        }

        public static void Disable()
        {
            Buff horseBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (horseBuff != null)
            {
                horseBuff.millisecondsDuration = 0;
            }
        }
    }
}
