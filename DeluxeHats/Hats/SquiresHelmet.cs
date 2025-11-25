using StardewValley;
using StardewValley.Buffs;
using System;
using System.Linq;

namespace DeluxeHats.Hats
{
    public static class SquiresHelmet
    {
        public const string Name = "Squire's Helmet";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff squireBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (squireBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.Defense.Set(2);
                    effects.Attack.Set(2);
                    squireBuff = new Buff(
                        id: HatService.BuffId,
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.squires-helmet.name"),
                        displayName: HatService.GetTranslation("hat.squires-helmet.buff.name"),
                        effects: effects
                        );
                    squireBuff.description = HatService.GetTranslation("hat.squires-helmet.buff.description");
                    squireBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(squireBuff);
                }
            };
        }

        public static void Disable()
        {
            if (HatService.CurrentPlayer == null) return;

            Buff squireBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (squireBuff != null)
            {
                squireBuff.millisecondsDuration = 0;
            }
        }
    }
}
