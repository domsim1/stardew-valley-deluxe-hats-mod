using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class Daisy
    {
        public const string Name = "Daisy";
        public const string Description = "Gain the Flower Child Buff:\n+2 Farming";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff daisyBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
                if (daisyBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.FarmingLevel.Set(2);
                    daisyBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Flower Child",
                        effects: effects
                        );
                    daisyBuff.description = "Flower Child\n+2 Farming";
                    daisyBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(daisyBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff daisyBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
            if (daisyBuff != null)
            {
                daisyBuff.millisecondsDuration = 0;
            }
        }
    }
}
