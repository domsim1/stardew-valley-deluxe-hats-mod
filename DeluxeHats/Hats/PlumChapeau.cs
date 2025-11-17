using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class PlumChapeau
    {
        public const string Name = "Plum Chapeau";
        public const string Description = "Gain the Royal Elegance Buff:\n+1 Luck";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff plumBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (plumBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.LuckLevel.Set(1);
                    plumBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Royal Elegance",
                        effects: effects
                        );
                    plumBuff.description = "Royal Elegance\n+1 Luck";
                    plumBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(plumBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff plumBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (plumBuff != null)
            {
                plumBuff.millisecondsDuration = 0;
            }
        }
    }
}
