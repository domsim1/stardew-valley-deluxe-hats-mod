using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class LeprechaunHat
    {
        public const string Name = "Leprechaun Hat";
        public const string Description = "Gain the Lucky Gold Buff:\n+3 Luck, +2 Farming";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff buff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
                if (buff == null)
                {
                    var effects = new BuffEffects();
                    effects.LuckLevel.Set(3);
                    effects.FarmingLevel.Set(2);
                    buff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Lucky Gold",
                        effects: effects
                        );
                    buff.description = "Lucky Gold\n+3 Luck, +2 Farming";
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
