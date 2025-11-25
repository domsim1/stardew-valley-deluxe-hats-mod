using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class BowlerHat
    {
        public const string Name = "Bowler Hat";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff bowlerBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (bowlerBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.Defense.Set(1);
                    bowlerBuff = new Buff(
                        id: HatService.BuffId,
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.bowler-hat.name"),
                        displayName: HatService.GetTranslation("hat.bowler-hat.buff.name"),
                        effects: effects
                        );
                    bowlerBuff.description = HatService.GetTranslation("hat.bowler-hat.buff.description");
                    bowlerBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(bowlerBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff bowlerBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (bowlerBuff != null)
            {
                bowlerBuff.millisecondsDuration = 0;
            }
        }
    }
}
