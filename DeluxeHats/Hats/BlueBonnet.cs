using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class BlueBonnet
    {
        public const string Name = "Blue Bonnet";
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
                        effects.ForagingLevel.Set(2);
                        effects.FarmingLevel.Set(1);
                        effects.FishingLevel.Set(1);
                        coolCapBuff = new Buff(
                            id: HatService.BuffId,
                            source: HatService.GetTranslation("mod.name"),
                            displaySource: HatService.GetTranslation("hat.blue-bonnet.name"),
                            displayName: HatService.GetTranslation("hat.blue-bonnet.buff.name"),
                            effects: effects
                            );
                        coolCapBuff.description = HatService.GetTranslation("hat.blue-bonnet.buff.description");
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
