using StardewValley;
using StardewValley.Buffs;
using StardewValley.Characters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeluxeHats.Hats
{
    public static class PumpkinMask
    {
        public const string Name = "Pumpkin Mask";
        public const string Description = "Gain the Spooky Buff:\n+2 Speed";

        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff propellerBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (propellerBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.Speed.Set(2);
                    propellerBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Pumpkin Mask",
                        effects: effects
                        );
                    propellerBuff.description = "Spooky\n+2 Speed";
                    propellerBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(propellerBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff propellerBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (propellerBuff != null)
            {
                propellerBuff.millisecondsDuration = 0;
            }
        }
    }
}
