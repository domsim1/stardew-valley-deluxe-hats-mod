using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class Earmuffs
    {
        public const string Name = "Earmuffs";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                if (HatService.CurrentPlayer?.currentLocation == null)
                    return;
                Buff earmuffBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (HatService.CurrentPlayer.currentLocation.IsOutdoors && Game1.currentSeason == "winter")
                {
                    if (earmuffBuff == null)
                    {
                        var effects = new BuffEffects();
                        effects.ForagingLevel.Set(2);
                        effects.FarmingLevel.Set(1);
                        effects.FishingLevel.Set(1);
                        earmuffBuff = new Buff(
                            id: HatService.BuffId,
                            source: HatService.GetTranslation("mod.name"),
                            displaySource: HatService.GetTranslation("hat.earmuffs.name"),
                            displayName: HatService.GetTranslation("hat.earmuffs.buff.name"),
                            effects: effects
                            );
                        earmuffBuff.description = HatService.GetTranslation("hat.earmuffs.buff.description");
                        earmuffBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                        HatService.CurrentPlayer.applyBuff(earmuffBuff);
                    }
                }
                else
                {
                    if (earmuffBuff != null)
                    {
                        earmuffBuff.millisecondsDuration = 0;
                    }
                }
            };
        }

        public static void Disable()
        {
            Buff earmuffBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (earmuffBuff != null)
            {
                earmuffBuff.millisecondsDuration = 0;
            }
        }
    }
}
