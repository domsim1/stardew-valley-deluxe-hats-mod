using StardewValley;
using StardewValley.Buffs;
using System;
using System.Linq;
using System.Collections.Generic;

namespace DeluxeHats.Hats
{
    public static class FishingHat
    {
        public const string Name = "Fishing Hat";
        public const string Description = "While outside and not on the beach get the Shaded Buff:\n+2 Fishing";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff fishingBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
                if (!Game1.currentLocation.IsOutdoors || Game1.currentLocation.Name.Contains("Beach"))
                {
                    if (fishingBuff != null)
                    {
                        fishingBuff.millisecondsDuration = 0;
                    }
                    return;
                }
                if (fishingBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.FishingLevel.Set(2);
                    fishingBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Shaded",
                        effects: effects
                        );
                    fishingBuff.description = "Shaded\n+2 Fishing";
                    fishingBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    var buffsList = (List<Buff>)HatService.Helper.Reflection.GetField<List<Buff>>(Game1.buffsDisplay, "buffs").GetValue();
                    buffsList.Add(fishingBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff fishinBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
            if (fishinBuff != null)
            {
                fishinBuff.millisecondsDuration = 0;
            }
        }
    }
}
