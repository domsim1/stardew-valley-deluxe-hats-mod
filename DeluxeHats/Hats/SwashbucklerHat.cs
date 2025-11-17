using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class SwashbucklerHat
    {
        public const string Name = "Swashbuckler Hat";
        public const string Description = "Gain the Swashbuckling Buff:\n+3 Attack, +2 Speed";

        public static void Activate()
        {
            var effects = new BuffEffects();
            effects.Attack.Set(3);
            effects.Speed.Set(2);

            var buff = new Buff(
                id: HatService.BuffId,
                source: "Deluxe Hats",
                displaySource: Name,
                displayName: "Swashbuckling",
                effects: effects
            );
            buff.description = "Swashbuckling\n+3 Attack\n+2 Speed";
            buff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
            HatService.CurrentPlayer.applyBuff(buff);

            HatService.OnTimeChanged = (e) =>
            {
                Buff swashBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
                if (swashBuff != null)
                {
                    swashBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                }
            };
        }

        public static void Disable()
        {
            Buff swashBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
            if (swashBuff != null)
            {
                swashBuff.millisecondsDuration = 0;
            }
        }
    }
}
