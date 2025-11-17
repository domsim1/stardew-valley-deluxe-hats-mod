using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class PropellerHat
    {
        public const string Name = "Propeller Hat";
        public const string Description = "Gain the Airborne Buff:\n+1 Speed";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff propellerBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (propellerBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.Speed.Set(1);
                    propellerBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Airborne",
                        effects: effects
                        );
                    propellerBuff.description = "Airborne\n+1 Speed";
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
