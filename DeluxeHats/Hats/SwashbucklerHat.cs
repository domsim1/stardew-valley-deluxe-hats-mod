using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class SwashbucklerHat
    {
        public const string Name = "Swashbuckler Hat";

        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff buff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (buff == null)
                {
                    var effects = new BuffEffects();
                    effects.Attack.Set(2);
                    effects.Speed.Set(1);

                    buff = new Buff(
                        id: HatService.BuffId,
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.swashbuckler-hat.name"),
                        displayName: HatService.GetTranslation("hat.swashbuckler-hat.buff.name"),
                        effects: effects
                    );
                    buff.description = HatService.GetTranslation("hat.swashbuckler-hat.buff.description");
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
