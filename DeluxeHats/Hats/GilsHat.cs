using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class GilsHat
    {
        public const string Name = "Gil's Hat";
        public const string Description = "Gain the Carpenter's Pride Buff:\n+2 Farming, +1 Defense";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff buff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
                if (buff == null)
                {
                    var effects = new BuffEffects();
                    effects.FarmingLevel.Set(2);
                    effects.Defense.Set(1);
                    buff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Carpenter's Pride",
                        effects: effects
                        );
                    buff.description = "Carpenter's Pride\n+2 Farming, +1 Defense";
                    buff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    Game1.player.applyBuff(buff);
                }
            };
        }

        public static void Disable()
        {
            Buff buff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
            if (buff != null)
            {
                buff.millisecondsDuration = 0;
            }
        }
    }
}
