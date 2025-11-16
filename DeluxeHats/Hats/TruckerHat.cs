using StardewValley;
using StardewValley.Buffs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeluxeHats.Hats
{
    public static class TruckerHat
    {
        public const string Name = "Trucker Hat";
        public const string Description = "When outside in summer get the Season Protection Buff:\n+2 Foraging\n+1 Farming\n+1 Fishing";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff truckerHatBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
                if (Game1.currentLocation.isOutdoors.Value && Game1.currentSeason == "summer")
                {
                    if (truckerHatBuff == null)
                    {
                        var effects = new BuffEffects();
                        effects.FarmingLevel.Set(1);
                        effects.FishingLevel.Set(1);
                        effects.ForagingLevel.Set(2);
                        truckerHatBuff = new Buff(
                            id: HatService.BuffId,
                            source: "Deluxe Hats",
                            displaySource: Name,
                            displayName: "Season Protection",
                            effects: effects
                            );
                        truckerHatBuff.description = "Season Protection\n+2 Foraging\n+1 Farming\n+1 Fishing";
                        truckerHatBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                        var buffsList = (List<Buff>)HatService.Helper.Reflection.GetField<List<Buff>>(Game1.buffsDisplay, "buffs").GetValue();
                        buffsList.Add(truckerHatBuff);
                    }
                }
                else
                {
                    if (truckerHatBuff != null)
                    {
                        truckerHatBuff.millisecondsDuration = 0;
                    }
                }
            };
        }

        public static void Disable()
        {
            Buff truckerHatBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
            if (truckerHatBuff != null)
            {
                truckerHatBuff.millisecondsDuration = 0;
            }
        }
    }
}
