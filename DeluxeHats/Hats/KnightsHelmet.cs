using StardewValley;
using StardewValley.Buffs;
using System;
using System.Linq;

namespace DeluxeHats.Hats
{
    public static class KnightsHelmet
    {
        public const string Name = "Knight's Helmet";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff knightBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (knightBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.Defense.Set(4);
                    effects.Immunity.Set(2);
                    knightBuff = new Buff(
                        id: HatService.BuffId,
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.knights-helmet.name"),
                        displayName: HatService.GetTranslation("hat.knights-helmet.buff.name"),
                        effects: effects
                        );
                    knightBuff.description = HatService.GetTranslation("hat.knights-helmet.buff.description");
                    knightBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(knightBuff);
                }
            };
        }

        public static void Disable()
        {
            if (HatService.CurrentPlayer == null) return;

            Buff knightBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (knightBuff != null)
            {
                knightBuff.millisecondsDuration = 0;
            }
        }
    }
}
