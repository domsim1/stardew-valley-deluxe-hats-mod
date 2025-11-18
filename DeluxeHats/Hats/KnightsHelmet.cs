using StardewValley;
using StardewValley.Buffs;
using System;
using System.Linq;

namespace DeluxeHats.Hats
{
    public static class KnightsHelmet
    {
        public const string Name = "Knight's Helmet";
        public const string Description = "Gain the Knight's Valor Buff:\n+4 Defense, +2 Immunity";
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
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Knight's Valor",
                        effects: effects
                        );
                    knightBuff.description = "Knight's Valor\n+4 Defense, +2 Immunity";
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
