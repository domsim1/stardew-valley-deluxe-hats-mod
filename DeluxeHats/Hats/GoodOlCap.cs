using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class GoodOlCap
    {
        public const string Name = "Good Ol' Cap";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                if (HatService.CurrentPlayer?.currentLocation == null)
                    return;
                Buff goodOlCapBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (HatService.CurrentPlayer.currentLocation.IsOutdoors && (Game1.currentSeason == "spring" || Game1.currentSeason == "fall" || Game1.currentSeason == "summer"))
                {
                    if (goodOlCapBuff == null)
                    {
                        var effects = new BuffEffects();
                        effects.ForagingLevel.Set(2);
                        goodOlCapBuff = new Buff(
                            id: HatService.BuffId,
                            source: HatService.GetTranslation("mod.name"),
                            displaySource: HatService.GetTranslation("hat.good-ol-cap.name"),
                            displayName: HatService.GetTranslation("hat.good-ol-cap.buff.name"),
                            effects: effects
                            );
                        goodOlCapBuff.description = HatService.GetTranslation("hat.good-ol-cap.buff.description");
                        goodOlCapBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                        HatService.CurrentPlayer.applyBuff(goodOlCapBuff);
                    }
                }
                else
                {
                    if (goodOlCapBuff != null)
                    {
                        goodOlCapBuff.millisecondsDuration = 0;
                    }
                }
            };
        }

        public static void Disable()
        {
            Buff goodOlCapBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (goodOlCapBuff != null)
            {
                goodOlCapBuff.millisecondsDuration = 0;
            }
        }
    }
}
