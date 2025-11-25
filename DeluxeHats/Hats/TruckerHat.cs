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
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                if (HatService.CurrentPlayer?.currentLocation == null)
                    return;
                Buff truckerHatBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (HatService.CurrentPlayer.currentLocation.IsOutdoors && Game1.currentSeason == "summer")
                {
                    if (truckerHatBuff == null)
                    {
                        var effects = new BuffEffects();
                        effects.FarmingLevel.Set(1);
                        effects.FishingLevel.Set(1);
                        effects.ForagingLevel.Set(2);
                        truckerHatBuff = new Buff(
                            id: HatService.BuffId,
                            source: HatService.GetTranslation("mod.name"),
                            displaySource: HatService.GetTranslation("hat.trucker-hat.name"),
                            displayName: HatService.GetTranslation("hat.trucker-hat.buff.name"),
                            effects: effects
                            );
                        truckerHatBuff.description = HatService.GetTranslation("hat.trucker-hat.buff.description");
                        truckerHatBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                        HatService.CurrentPlayer.applyBuff(truckerHatBuff);
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
            Buff truckerHatBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (truckerHatBuff != null)
            {
                truckerHatBuff.millisecondsDuration = 0;
            }
        }
    }
}
