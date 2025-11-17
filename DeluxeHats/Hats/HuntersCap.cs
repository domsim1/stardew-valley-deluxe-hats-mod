using StardewValley;
using StardewValley.Buffs;
using System;
using System.Linq;

namespace DeluxeHats.Hats
{
    public static class HuntersCap
    {
        public const string Name = "Hunter's Cap";
        public const string Description = "When outside in fall get the Season Protection Buff:\n+2 Foraging\n+1 Farming\n+1 Fishing";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff huntersCapBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (HatService.CurrentPlayer.currentLocation.isOutdoors.Value && Game1.currentSeason == "fall")
                {
                    if (huntersCapBuff == null)
                    {
                        var effects = new BuffEffects();
                        effects.FarmingLevel.Set(1);
                        effects.FishingLevel.Set(1);
                        effects.ForagingLevel.Set(2);
                        huntersCapBuff = new Buff(
                            id: HatService.BuffId,
                            source: "Deluxe Hats",
                            displaySource: Name,
                            displayName: "Season Protection",
                            effects: effects
                            );
                        huntersCapBuff.description = "Season Protection\n+2 Foraging\n+1 Farming\n+1 Fishing";
                        huntersCapBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                        HatService.CurrentPlayer.applyBuff(huntersCapBuff);
                    }
                }
                else
                {
                    if (huntersCapBuff != null)
                    {
                        huntersCapBuff.millisecondsDuration = 0;
                    }
                }
            };
        }

        public static void Disable()
        {
            Buff huntersCapBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (huntersCapBuff != null)
            {
                huntersCapBuff.millisecondsDuration = 0;
            }
        }
    }
}
