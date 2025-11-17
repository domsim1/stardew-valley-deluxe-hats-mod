using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class LogoCap
    {
        public const string Name = "Logo Cap";
        public const string Description = "Gain the Brand Ambassador Buff:\n+1 Defense\n+1 Attack";
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
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Brand Ambassador",
                        effects: effects
                        );
                    logoBuff.description = "Brand Ambassador\n+1 Defense\n+1 Attack";
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
