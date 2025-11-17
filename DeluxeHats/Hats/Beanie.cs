using StardewValley;
using StardewValley.Buffs;
using System;
using System.Linq;

namespace DeluxeHats.Hats
{
    public static class Beanie
    {
        public const string Name = "Beanie";
        public const string Description = "Gain Burglar's Luck Buff:\n+2 Luck\n+2 Attack";

        public static void Activate()
        {
            var effects = new BuffEffects();
            effects.LuckLevel.Set(2);
            effects.Attack.Set(2);

            var buff = new Buff(
                id: HatService.BuffId,
                source: "Deluxe Hats",
                displaySource: Name,
                displayName: "Burglar's Luck",
                effects: effects
            );
            buff.description = "Burglar's Luck\n+2 Luck\n+2 Attack";
            buff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
            HatService.CurrentPlayer.applyBuff(buff);

            HatService.OnTimeChanged = (e) =>
            {
                Buff beanieBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (beanieBuff != null)
                {
                    beanieBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                }
            };
        }

        public static void Disable()
        {
            Buff beanieBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (beanieBuff != null)
            {
                beanieBuff.millisecondsDuration = 0;
            }
        }
    }
}
