using StardewValley;
using StardewValley.Buffs;
using System;
using System.Linq;

namespace DeluxeHats.Hats
{
    public static class ArchersCap
    {
        public const string Name = "Archer's Cap";
        public const string Description = "Gain the Precision Aim Buff:\n+2 Attack, +1 Speed, +1 Defense";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff archerBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (archerBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.Attack.Set(2);
                    effects.Speed.Set(1);
                    effects.Defense.Set(1);
                    archerBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Precision Aim",
                        effects: effects
                        );
                    archerBuff.description = "Precision Aim\n+2 Attack, +1 Speed, +1 Defense";
                    archerBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(archerBuff);
                }
            };
        }

        public static void Disable()
        {
            if (HatService.CurrentPlayer == null) return;

            Buff archerBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (archerBuff != null)
            {
                archerBuff.millisecondsDuration = 0;
            }
        }
    }
}
