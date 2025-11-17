using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class LivingHat
    {
        public const string Name = "Living Hat";
        public const string Description = "Gain the Living Bond Buff:\n+2 Farming";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff livingBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (livingBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.FarmingLevel.Set(2);
                    livingBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Living Bond",
                        effects: effects
                        );
                    livingBuff.description = "Living Bond\n+2 Farming";
                    livingBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(livingBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff livingBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (livingBuff != null)
            {
                livingBuff.millisecondsDuration = 0;
            }
        }
    }
}
