using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class ElegantTurban
    {
        public const string Name = "Elegant Turban";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff elegantBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (elegantBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.LuckLevel.Set(4);
                    effects.FarmingLevel.Set(3);
                    effects.FishingLevel.Set(3);
                    effects.ForagingLevel.Set(3);
                    effects.MiningLevel.Set(3);
                    effects.Speed.Set(2);
                    elegantBuff = new Buff(
                        id: HatService.BuffId,
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.elegant-turban.name"),
                        displayName: HatService.GetTranslation("hat.elegant-turban.buff.name"),
                        effects: effects
                        );
                    elegantBuff.description = HatService.GetTranslation("hat.elegant-turban.buff.description");
                    elegantBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(elegantBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff elegantBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (elegantBuff != null)
            {
                elegantBuff.millisecondsDuration = 0;
            }
        }
    }
}
