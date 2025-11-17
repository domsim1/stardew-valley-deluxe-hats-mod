using StardewValley;
using StardewValley.Buffs;
using System;
using System.Linq;

namespace DeluxeHats.Hats
{
    public static class WitchHat
    {
        public const string Name = "Witch Hat";
        public const string Description = "Gain Witching Hour Buff:\n+2 Luck\n+2 Foraging";

        public static void Activate()
        {
            var effects = new BuffEffects();
            effects.LuckLevel.Set(2);
            effects.ForagingLevel.Set(2);

            var buff = new Buff(
                id: HatService.BuffId,
                source: "Deluxe Hats",
                displaySource: Name,
                displayName: "Witching Hour",
                effects: effects
            );
            buff.description = "Witching Hour\n+2 Luck\n+2 Foraging";
            buff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
            HatService.CurrentPlayer.applyBuff(buff);
        }

        public static void Disable()
        {
            Buff witchBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (witchBuff != null)
            {
                witchBuff.millisecondsDuration = 0;
            }
        }
    }
}
