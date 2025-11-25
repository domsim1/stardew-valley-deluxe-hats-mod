using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class Daisy
    {
        public const string Name = "Daisy";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff daisyBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (daisyBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.FarmingLevel.Set(2);
                    daisyBuff = new Buff(
                        id: HatService.BuffId,
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.daisy.name"),
                        displayName: HatService.GetTranslation("hat.daisy.buff.name"),
                        effects: effects
                        );
                    daisyBuff.description = HatService.GetTranslation("hat.daisy.buff.description");
                    daisyBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(daisyBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff daisyBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (daisyBuff != null)
            {
                daisyBuff.millisecondsDuration = 0;
            }
        }
    }
}
