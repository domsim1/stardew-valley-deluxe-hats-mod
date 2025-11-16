using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class PinkBow
    {
        public const string Name = "Pink Bow";
        public const string Description = "Gain the Sweet Charm Buff:\n+1 Luck, +1 Foraging";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff buff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
                if (buff == null)
                {
                    var effects = new BuffEffects();
                    effects.LuckLevel.Set(1);
                    effects.ForagingLevel.Set(1);
                    buff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Sweet Charm",
                        effects: effects
                        );
                    buff.description = "Sweet Charm\n+1 Luck, +1 Foraging";
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
