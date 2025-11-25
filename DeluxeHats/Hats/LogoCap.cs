using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class LogoCap
    {
        public const string Name = "Logo Cap";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff logoBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (logoBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.Defense.Set(1);
                    effects.Attack.Set(1);
                    logoBuff = new Buff(
                        id: HatService.BuffId,
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.logo-cap.name"),
                        displayName: HatService.GetTranslation("hat.logo-cap.buff.name"),
                        effects: effects
                        );
                    logoBuff.description = HatService.GetTranslation("hat.logo-cap.buff.description");
                    logoBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(logoBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff logoBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (logoBuff != null)
            {
                logoBuff.millisecondsDuration = 0;
            }
        }
    }
}
