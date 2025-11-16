using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class EyePatch
    {
        public const string Name = "Eye Patch";
        public const string Description = "Gain the Pirate Vision Buff:\n+1 Attack";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff pirateBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
                if (pirateBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.Attack.Set(1);
                    pirateBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Pirate Vision",
                        effects: effects
                        );
                    pirateBuff.description = "Pirate Vision\n+1 Attack";
                    pirateBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    Game1.player.applyBuff(pirateBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff pirateBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
            if (pirateBuff != null)
            {
                pirateBuff.millisecondsDuration = 0;
            }
        }
    }
}
