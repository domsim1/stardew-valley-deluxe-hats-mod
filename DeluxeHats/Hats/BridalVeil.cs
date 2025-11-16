using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class BridalVeil
    {
        public const string Name = "Bridal Veil";
        public const string Description = "Gain the Blissful Buff:\n+2 Luck";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff bridalBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
                if (bridalBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.LuckLevel.Set(2);
                    bridalBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Blissful",
                        effects: effects
                        );
                    bridalBuff.description = "Blissful\n+2 Luck";
                    bridalBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    Game1.player.applyBuff(bridalBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff bridalBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
            if (bridalBuff != null)
            {
                bridalBuff.millisecondsDuration = 0;
            }
        }
    }
}
