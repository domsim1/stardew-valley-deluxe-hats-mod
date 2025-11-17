using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class StarHelmet
    {
        public const string Name = "Star Helmet";
        public const string Description = "Gain the Starlight Protection Buff:\n+2 Defense, +2 Mining, +1 Luck";

        public static void Activate()
        {
            var effects = new BuffEffects();
            effects.Defense.Set(2);
            effects.MiningLevel.Set(2);
            effects.LuckLevel.Set(1);

            var buff = new Buff(
                id: HatService.BuffId,
                source: "Deluxe Hats",
                displaySource: Name,
                displayName: "Starlight Protection",
                effects: effects
            );
            buff.description = "Starlight Protection\n+2 Defense\n+2 Mining\n+1 Luck";
            buff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
            HatService.CurrentPlayer.applyBuff(buff);

            HatService.OnTimeChanged = (e) =>
            {
                Buff starBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (starBuff != null)
                {
                    starBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                }
            };
        }

        public static void Disable()
        {
            Buff starBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (starBuff != null)
            {
                starBuff.millisecondsDuration = 0;
            }
        }
    }
}
