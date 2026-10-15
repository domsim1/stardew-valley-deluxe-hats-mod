using StardewValley;
using System;
using System.Linq;
using DeluxeHats.Utils;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class GoldPan
    {
        public const string Name = "Gold Pan";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff buff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (buff == null)
                {
                    var effects = new BuffEffects();
                    effects.MiningLevel.Set(2);
                    effects.LuckLevel.Set(2);
                    buff = new Buff(
                        id: HatService.BuffId,
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.gold-pan.name"),
                        displayName: HatService.GetTranslation("hat.gold-pan.buff.name"),
                        effects: effects
                        );
                    buff.description = HatService.GetTranslation("hat.gold-pan.buff.description");
                    buff.millisecondsDuration = HatService.GetBuffDuration(20f);
                    HatService.CurrentPlayer.applyBuff(buff);
                }

                Prospector.Update(HatService.CurrentPlayer, showDirection: true);
            };
        }

        public static void Disable()
        {
            Prospector.Reset(HatService.CurrentPlayer);
            Buff buff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (buff != null)
            {
                buff.millisecondsDuration = 0;
            }
        }
    }
}
