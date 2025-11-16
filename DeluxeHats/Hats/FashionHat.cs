using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class FashionHat
    {
        public const string Name = "Fashion Hat";
        public const string Description = "Gain the Fashionable Buff:\n+2 Luck";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff fashionBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
                if (fashionBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.LuckLevel.Set(2);
                    fashionBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Fashionable",
                        effects: effects
                        );
                    fashionBuff.description = "Fashionable\n+2 Luck";
                    fashionBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    Game1.player.applyBuff(fashionBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff fashionBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
            if (fashionBuff != null)
            {
                fashionBuff.millisecondsDuration = 0;
            }
        }
    }
}
