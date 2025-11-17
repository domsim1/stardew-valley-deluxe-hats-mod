using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class ConeHat
    {
        public const string Name = "Cone Hat";
        public const string Description = "Gain the Celebratory Buff:\n+1 Luck";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff coneBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
                if (coneBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.LuckLevel.Set(1);
                    coneBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Celebratory",
                        effects: effects
                        );
                    coneBuff.description = "Celebratory\n+1 Luck";
                    coneBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(coneBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff coneBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
            if (coneBuff != null)
            {
                coneBuff.millisecondsDuration = 0;
            }
        }
    }
}
