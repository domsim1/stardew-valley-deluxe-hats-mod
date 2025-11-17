using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class Sunglasses
    {
        public const string Name = "Sunglasses";
        public const string Description = "Gain the Cool and Collected Buff:\n+2 Luck, +1 Speed";

        public static void Activate()
        {
            var effects = new BuffEffects();
            effects.LuckLevel.Set(2);
            effects.Speed.Set(1);

            var buff = new Buff(
                id: HatService.BuffId,
                source: "Deluxe Hats",
                displaySource: Name,
                displayName: "Cool and Collected",
                effects: effects
            );
            buff.description = "Cool and Collected\n+2 Luck\n+1 Speed";
            buff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
            HatService.CurrentPlayer.applyBuff(buff);

            HatService.OnTimeChanged = (e) =>
            {
                Buff coolBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
                if (coolBuff != null)
                {
                    coolBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                }
            };
        }

        public static void Disable()
        {
            Buff coolBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
            if (coolBuff != null)
            {
                coolBuff.millisecondsDuration = 0;
            }
        }
    }
}
