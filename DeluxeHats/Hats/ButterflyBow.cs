using StardewValley;
using StardewValley.Buffs;
using System;
using System.Linq;

namespace DeluxeHats.Hats
{
    public static class ButterflyBow
    {
        public const string Name = "Butterfly Bow";
        public const string Description = "Gain the Graceful Flight Buff:\n+2 Luck, +1 Foraging, +1 Farming";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff butterflyBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (butterflyBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.LuckLevel.Set(2);
                    effects.ForagingLevel.Set(1);
                    effects.FarmingLevel.Set(1);
                    butterflyBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Graceful Flight",
                        effects: effects
                        );
                    butterflyBuff.description = "Graceful Flight\n+2 Luck, +1 Foraging, +1 Farming";
                    butterflyBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(butterflyBuff);
                }
            };
        }

        public static void Disable()
        {
            if (HatService.CurrentPlayer == null) return;

            Buff butterflyBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (butterflyBuff != null)
            {
                butterflyBuff.millisecondsDuration = 0;
            }
        }
    }
}
