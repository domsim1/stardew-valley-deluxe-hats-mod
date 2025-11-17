using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class EmilysMagicHat
    {
        public const string Name = "Emily's Magic Hat";
        public const string Description = "Gain the Magical Aura Buff:\n+3 Luck";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff emilyBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (emilyBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.LuckLevel.Set(3);
                    emilyBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Magical Aura",
                        effects: effects
                        );
                    emilyBuff.description = "Magical Aura\n+3 Luck";
                    emilyBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(emilyBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff emilyBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (emilyBuff != null)
            {
                emilyBuff.millisecondsDuration = 0;
            }
        }
    }
}
