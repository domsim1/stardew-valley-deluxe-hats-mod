using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class FashionHat
    {
        public const string Name = "Fashion Hat";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff fashionBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (fashionBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.LuckLevel.Set(2);
                    fashionBuff = new Buff(
                        id: HatService.BuffId,
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.fashion-hat.name"),
                        displayName: HatService.GetTranslation("hat.fashion-hat.buff.name"),
                        effects: effects
                        );
                    fashionBuff.description = HatService.GetTranslation("hat.fashion-hat.buff.description");
                    fashionBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(fashionBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff fashionBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (fashionBuff != null)
            {
                fashionBuff.millisecondsDuration = 0;
            }
        }
    }
}
