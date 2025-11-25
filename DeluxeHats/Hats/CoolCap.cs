using StardewValley;
using StardewValley.Buffs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeluxeHats.Hats
{
    public static class CoolCap
    {
        public const string Name = "Cool Cap";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                if (HatService.CurrentPlayer?.currentLocation == null)
                    return;
                Buff coolCapBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (HatService.CurrentPlayer.currentLocation.IsOutdoors && Game1.currentSeason == "spring")
                {
                    if (coolCapBuff == null)
                    {
                        var effects = new BuffEffects();
                        effects.FarmingLevel.Set(1);
                        effects.FishingLevel.Set(1);
                        effects.ForagingLevel.Set(2);
                        coolCapBuff = new Buff(
                            id: HatService.BuffId,
                            source: HatService.GetTranslation("mod.name"),
                            displaySource: HatService.GetTranslation("hat.cool-cap.name"),
                            displayName: HatService.GetTranslation("hat.cool-cap.buff.name"),
                            effects: effects
                            );
                        coolCapBuff.description = HatService.GetTranslation("hat.cool-cap.buff.description");
                        coolCapBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                        HatService.CurrentPlayer.applyBuff(coolCapBuff);
                    }
                }
                else
                {
                    if (coolCapBuff != null)
                    {
                        coolCapBuff.millisecondsDuration = 0;
                    }
                }
            };
        }

        public static void Disable()
        {
            Buff coolCapBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (coolCapBuff != null)
            {
                coolCapBuff.millisecondsDuration = 0;
            }
        }
    }
}
