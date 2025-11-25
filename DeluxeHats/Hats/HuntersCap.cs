using StardewValley;
using StardewValley.Buffs;
using System;
using System.Linq;

namespace DeluxeHats.Hats
{
    public static class HuntersCap
    {
        public const string Name = "Hunter's Cap";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                if (HatService.CurrentPlayer?.currentLocation == null)
                    return;
                Buff huntersCapBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (HatService.CurrentPlayer.currentLocation.IsOutdoors && Game1.currentSeason == "fall")
                {
                    if (huntersCapBuff == null)
                    {
                        var effects = new BuffEffects();
                        effects.FarmingLevel.Set(1);
                        effects.FishingLevel.Set(1);
                        effects.ForagingLevel.Set(2);
                        huntersCapBuff = new Buff(
                            id: HatService.BuffId,
                            source: HatService.GetTranslation("mod.name"),
                            displaySource: HatService.GetTranslation("hat.hunters-cap.name"),
                            displayName: HatService.GetTranslation("hat.hunters-cap.buff.name"),
                            effects: effects
                            );
                        huntersCapBuff.description = HatService.GetTranslation("hat.hunters-cap.buff.description");
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
