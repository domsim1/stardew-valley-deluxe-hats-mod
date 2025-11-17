using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class OfficialCap
    {
        public const string Name = "Official Cap";
        public const string Description = "While on the Beach gain the Ol' Mariner Buff:\n+2 Fishing";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff fishingBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
                if (!Game1.currentLocation.name.Value.Contains("Beach"))
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
                        displayName: "Ol' Mariner",
                        effects: effects
                        );
                    fishingBuff.description = "Ol' Mariner\n+2 Fishing";
                    fishingBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(fishingBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff fishingBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
            if (fishingBuff != null)
            {
                fishingBuff.millisecondsDuration = 0;
            }
        }
    }
}
