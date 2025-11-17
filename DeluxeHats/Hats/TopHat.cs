using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class TopHat
    {
        public const string Name = "Top Hat";
        public const string Description = "Gain the Distinguished Gentleman Buff:\n+2 Luck";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff topHatBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (topHatBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.LuckLevel.Set(2);
                    topHatBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Distinguished Gentleman",
                        effects: effects
                        );
                    topHatBuff.description = "Distinguished Gentleman\n+2 Luck";
                    topHatBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(topHatBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff topHatBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (topHatBuff != null)
            {
                topHatBuff.millisecondsDuration = 0;
            }
        }
    }
}
