using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class CopperPan
    {
        public const string Name = "Copper Pan";
        public const string Description = "Gain the Prospector Buff:\n+2 Mining";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff copperBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (copperBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.MiningLevel.Set(2);
                    copperBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Prospector",
                        effects: effects
                        );
                    copperBuff.description = "Prospector\n+2 Mining";
                    copperBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(copperBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff copperBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (copperBuff != null)
            {
                copperBuff.millisecondsDuration = 0;
            }
        }
    }
}
