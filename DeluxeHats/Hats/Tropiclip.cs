using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class Tropiclip
    {
        public const string Name = "Tropiclip";
        public const string Description = "Gain the Tropical Paradise Buff:\n+2 Farming\n+1 Luck";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff tropiclipBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
                if (tropiclipBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.FarmingLevel.Set(2);
                    effects.LuckLevel.Set(1);
                    tropiclipBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Tropical Paradise",
                        effects: effects
                        );
                    tropiclipBuff.description = "Tropical Paradise\n+2 Farming\n+1 Luck";
                    tropiclipBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    Game1.player.applyBuff(tropiclipBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff tropiclipBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
            if (tropiclipBuff != null)
            {
                tropiclipBuff.millisecondsDuration = 0;
            }
        }
    }
}
