using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class GnomesCap
    {
        public const string Name = "Gnome's Cap";
        public const string Description = "Gain the Gnome Protection Buff:\n+1 Luck\n+1 Mining";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff gnomeBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
                if (gnomeBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.LuckLevel.Set(1);
                    effects.MiningLevel.Set(1);
                    gnomeBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Gnome Protection",
                        effects: effects
                        );
                    gnomeBuff.description = "Gnome Protection\n+1 Luck\n+1 Mining";
                    gnomeBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(gnomeBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff gnomeBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
            if (gnomeBuff != null)
            {
                gnomeBuff.millisecondsDuration = 0;
            }
        }
    }
}
