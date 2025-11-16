using System;
using System.Linq;
using StardewValley;
using StardewValley.Buffs;
using System.Collections.Generic;

namespace DeluxeHats.Hats
{
    public static class StrawHat
    {
        public const string Name = "Straw Hat";
        public const string Description = "When it's dawn and sunny, gain Dawn Farming Buff:\n+3 Farming";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                if (Game1.isRaining || Game1.IsWinter)
                {
                    return;
                }
                if (Game1.timeOfDay > 930)
                {
                    return;
                }
                Buff farmingBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
                if (farmingBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.FarmingLevel.Set(3);
                    farmingBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Dawn Farming",
                        effects: effects
                        );
                    farmingBuff.description = "Dawn Farming\n+3 Farming";
                    farmingBuff.millisecondsDuration = Convert.ToInt32((3.3f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    Game1.player.applyBuff(farmingBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff farmingBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
            if (farmingBuff != null)
            {
                farmingBuff.millisecondsDuration = 0;
            }
        }
    }
}
