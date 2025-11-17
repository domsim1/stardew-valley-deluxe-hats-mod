using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class WhiteBow
    {
        public const string Name = "White Bow";
        public const string Description = "Gain the Pure Elegance Buff:\n+2 Luck, +1 Foraging";

        public static void Activate()
        {
            var effects = new BuffEffects();
            effects.LuckLevel.Set(2);
            effects.ForagingLevel.Set(1);

            var buff = new Buff(
                id: HatService.BuffId,
                source: "Deluxe Hats",
                displaySource: Name,
                displayName: "Pure Elegance",
                effects: effects
            );
            buff.description = "Pure Elegance\n+2 Luck\n+1 Foraging";
            buff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
            HatService.CurrentPlayer.applyBuff(buff);

            HatService.OnTimeChanged = (e) =>
            {
                Buff whiteBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (whiteBuff != null)
                {
                    whiteBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                }
            };
        }

        public static void Disable()
        {
            Buff whiteBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (whiteBuff != null)
            {
                whiteBuff.millisecondsDuration = 0;
            }
        }
    }
}
