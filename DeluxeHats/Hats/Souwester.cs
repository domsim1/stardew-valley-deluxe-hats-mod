using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class Souwester
    {
        public const string Name = "Sou'wester";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                if (HatService.CurrentPlayer?.currentLocation == null)
                    return;
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
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.souwester.name"),
                        displayName: HatService.GetTranslation("hat.souwester.buff.name"),
                        effects: effects
                        );
                    fishingBuff.description = HatService.GetTranslation("hat.souwester.buff.description");
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
