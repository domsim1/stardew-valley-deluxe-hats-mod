using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class JunimoHat
    {
        public const string Name = "Junimo Hat";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff buff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (buff == null)
                {
                    var effects = new BuffEffects();
                    effects.FarmingLevel.Set(5);
                    effects.ForagingLevel.Set(5);
                    effects.LuckLevel.Set(3);
                    effects.Speed.Set(2);
                    buff = new Buff(
                        id: HatService.BuffId,
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.junimo-hat.name"),
                        displayName: HatService.GetTranslation("hat.junimo-hat.buff.name"),
                        effects: effects
                        );
                    buff.description = HatService.GetTranslation("hat.junimo-hat.buff.description");
                    buff.millisecondsDuration = HatService.GetBuffDuration(20f);
                    HatService.CurrentPlayer.applyBuff(buff);
                }
            };
        }

        public static void Disable()
        {
            Buff buff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (buff != null)
            {
                buff.millisecondsDuration = 0;
            }
        }
    }
}
