using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class UnknownHat
    {
        public const string Name = "???";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff unknownBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (unknownBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.FarmingLevel.Set(10);
                    effects.FishingLevel.Set(10);
                    effects.ForagingLevel.Set(10);
                    effects.MiningLevel.Set(10);
                    effects.LuckLevel.Set(10);
                    effects.Speed.Set(5);
                    effects.Defense.Set(5);
                    effects.Attack.Set(5);
                    effects.Immunity.Set(5);
                    unknownBuff = new Buff(
                        id: HatService.BuffId,
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.unknown.name"),
                        displayName: HatService.GetTranslation("hat.unknown.buff.name"),
                        effects: effects
                        );
                    unknownBuff.description = HatService.GetTranslation("hat.unknown.buff.description");
                    unknownBuff.millisecondsDuration = HatService.GetBuffDuration(20f);
                    HatService.CurrentPlayer.applyBuff(unknownBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff unknownBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (unknownBuff != null)
            {
                unknownBuff.millisecondsDuration = 0;
            }
        }
    }
}
