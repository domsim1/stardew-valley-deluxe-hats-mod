using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class GreenTurban
    {
        public const string Name = "Green Turban";
        public const string Description = "Gain the Jungle Mystic Buff:\n+1 Luck\n+1 Foraging";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff greenBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
                if (greenBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.LuckLevel.Set(1);
                    effects.ForagingLevel.Set(1);
                    greenBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Jungle Mystic",
                        effects: effects
                        );
                    greenBuff.description = "Jungle Mystic\n+1 Luck\n+1 Foraging";
                    greenBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(greenBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff greenBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
            if (greenBuff != null)
            {
                greenBuff.millisecondsDuration = 0;
            }
        }
    }
}
