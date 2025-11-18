using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class SantaHat
    {
        public const string Name = "Santa Hat";
        public const string Description = "Gain the Holiday Spirit Buff:\n+1 Luck\n+1 Farming";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff santaBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (santaBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.LuckLevel.Set(1);
                    effects.FarmingLevel.Set(1);
                    santaBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Holiday Spirit",
                        effects: effects
                        );
                    santaBuff.description = "Holiday Spirit\n+1 Luck\n+1 Farming";
                    santaBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(santaBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff santaBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (santaBuff != null)
            {
                santaBuff.millisecondsDuration = 0;
            }
        }
    }
}
