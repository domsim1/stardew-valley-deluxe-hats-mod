using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class Souwester
    {
        public const string Name = "Sou'wester";
        public const string Description = "While outside in the rain, gain the Fishing in the Rain Buff:\n+4 Fishing";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff fishingBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (!Game1.isRaining || !HatService.CurrentPlayer.currentLocation.IsOutdoors)
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
                    effects.FishingLevel.Set(4);
                    fishingBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Fishing in the Rain",
                        effects: effects
                        );
                    fishingBuff.description = "Fishing in the Rain\n+4 Fishing";
                    fishingBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(fishingBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff fishinBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (fishinBuff != null)
            {
                fishinBuff.millisecondsDuration = 0;
            }
        }
    }
}
