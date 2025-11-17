using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class SteelPan
    {
        public const string Name = "Steel Pan (hat)";
        public const string Description = "Gain the Steel Prospector Buff:\n+2 Mining, +1 Defense";

        public static void Activate()
        {
            var effects = new BuffEffects();
            effects.MiningLevel.Set(2);
            effects.Defense.Set(1);

            var buff = new Buff(
                id: HatService.BuffId,
                source: "Deluxe Hats",
                displaySource: Name,
                displayName: "Steel Prospector",
                effects: effects
            );
            buff.description = "Steel Prospector\n+2 Mining\n+1 Defense";
            buff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
            HatService.CurrentPlayer.applyBuff(buff);

            HatService.OnTimeChanged = (e) =>
            {
                Buff steelBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (steelBuff != null)
                {
                    steelBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                }
            };
        }

        public static void Disable()
        {
            Buff steelBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (steelBuff != null)
            {
                steelBuff.millisecondsDuration = 0;
            }
        }
    }
}
