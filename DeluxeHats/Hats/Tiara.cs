using StardewValley;
using StardewValley.Buffs;
using System;
using System.Linq;

namespace DeluxeHats.Hats
{
    public static class Tiara
    {
        public const string Name = "Tiara";
        public const string Description = "Gain Fairy Blessing Buff:\n+2 Luck\n+2 Farming";

        public static void Activate()
        {
            var effects = new BuffEffects();
            effects.LuckLevel.Set(2);
            effects.FarmingLevel.Set(2);

            var buff = new Buff(
                id: HatService.BuffId,
                source: "Deluxe Hats",
                displaySource: Name,
                displayName: "Fairy Blessing",
                effects: effects
            );
            buff.description = "Fairy Blessing\n+2 Luck\n+2 Farming";
            buff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
            HatService.CurrentPlayer.applyBuff(buff);

            HatService.OnTimeChanged = (e) =>
            {
                Buff tiaraBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (tiaraBuff != null)
                {
                    tiaraBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                }
            };
        }

        public static void Disable()
        {
            Buff tiaraBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (tiaraBuff != null)
            {
                tiaraBuff.millisecondsDuration = 0;
            }
        }
    }
}
