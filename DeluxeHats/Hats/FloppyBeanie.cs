using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class FloppyBeanie
    {
        public const string Name = "Floppy Beanie";
        public const string Description = "Gain the Cozy Buff:\n+1 Defense";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff floppyBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (floppyBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.Defense.Set(1);
                    floppyBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Cozy",
                        effects: effects
                        );
                    floppyBuff.description = "Cozy\n+1 Defense";
                    floppyBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(floppyBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff floppyBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (floppyBuff != null)
            {
                floppyBuff.millisecondsDuration = 0;
            }
        }
    }
}
