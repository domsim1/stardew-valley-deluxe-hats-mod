using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class MagicCowboyHat
    {
        public const string Name = "Magic Cowboy Hat";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff magicBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (HatService.CurrentPlayer.isRidingHorse())
                {
                    if (magicBuff == null)
                    {
                        var effects = new BuffEffects();
                        effects.Speed.Set(2);
                        effects.Attack.Set(1);
                        magicBuff = new Buff(
                            id: HatService.BuffId,
                            source: HatService.GetTranslation("mod.name"),
                            displaySource: HatService.GetTranslation("hat.magic-cowboy-hat.name"),
                            displayName: HatService.GetTranslation("hat.magic-cowboy-hat.buff.name"),
                            effects: effects
                            );
                        magicBuff.description = HatService.GetTranslation("hat.magic-cowboy-hat.buff.description");
                        magicBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                        HatService.CurrentPlayer.applyBuff(magicBuff);
                    }
                }
                else
                {
                    if (magicBuff != null)
                    {
                        magicBuff.millisecondsDuration = 0;
                    }
                }
            };
        }

        public static void Disable()
        {
            Buff magicBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (magicBuff != null)
            {
                magicBuff.millisecondsDuration = 0;
            }
        }
    }
}
