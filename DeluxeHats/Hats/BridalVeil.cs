using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class BridalVeil
    {
        public const string Name = "Bridal Veil";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff bridalBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (bridalBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.LuckLevel.Set(2);
                    bridalBuff = new Buff(
                        id: HatService.BuffId,
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.bridal-veil.name"),
                        displayName: HatService.GetTranslation("hat.bridal-veil.buff.name"),
                        effects: effects
                        );
                    bridalBuff.description = HatService.GetTranslation("hat.bridal-veil.buff.description");
                    bridalBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(bridalBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff bridalBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (bridalBuff != null)
            {
                bridalBuff.millisecondsDuration = 0;
            }
        }
    }
}
