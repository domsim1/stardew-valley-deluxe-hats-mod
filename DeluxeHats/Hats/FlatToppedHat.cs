using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class FlatToppedHat
    {
        public const string Name = "Flat Topped Hat";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff flatBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (flatBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.Defense.Set(1);
                    effects.LuckLevel.Set(1);
                    flatBuff = new Buff(
                        id: HatService.BuffId,
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.flat-topped-hat.name"),
                        displayName: HatService.GetTranslation("hat.flat-topped-hat.buff.name"),
                        effects: effects
                        );
                    flatBuff.description = HatService.GetTranslation("hat.flat-topped-hat.buff.description");
                    flatBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(flatBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff flatBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (flatBuff != null)
            {
                flatBuff.millisecondsDuration = 0;
            }
        }
    }
}
