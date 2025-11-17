using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class Earmuffs
    {
        public const string Name = "Earmuffs";
        public const string Description = "When outside in winter get the Season Protection Buff:\n+2 Foraging\n+1 Farming\n+1 Fishing";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff earmuffBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
                if (Game1.currentLocation.isOutdoors.Value && Game1.currentSeason == "winter")
                {
                    if (earmuffBuff == null)
                    {
                        var effects = new BuffEffects();
                        effects.ForagingLevel.Set(2);
                        effects.FarmingLevel.Set(1);
                        effects.FishingLevel.Set(1);
                        earmuffBuff = new Buff(
                            id: HatService.BuffId,
                            source: "Deluxe Hats",
                            displaySource: Name,
                            displayName: "Season Protection",
                            effects: effects
                            );
                        earmuffBuff.description = "Season Protection\n+2 Foraging\n+1 Farming\n+1 Fishing";
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
            Buff earmuffBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
            if (earmuffBuff != null)
            {
                earmuffBuff.millisecondsDuration = 0;
            }
        }
    }
}
