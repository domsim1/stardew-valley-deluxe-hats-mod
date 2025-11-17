using StardewValley;
using StardewValley.Buffs;
using System;
using System.Linq;

namespace DeluxeHats.Hats
{
    public static class PirateHat
    {
        public const string Name = "Pirate Hat";
        public const string Description = "Gain the Treasure Hunter Buff:\n+2 Fishing, +2 Luck";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff pirateBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (pirateBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.FishingLevel.Set(2);
                    effects.LuckLevel.Set(2);
                    pirateBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Treasure Hunter",
                        effects: effects
                        );
                    pirateBuff.description = "Treasure Hunter\n+2 Fishing, +2 Luck";
                    pirateBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(pirateBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff pirateBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (pirateBuff != null)
            {
                pirateBuff.millisecondsDuration = 0;
            }
        }
    }
}
