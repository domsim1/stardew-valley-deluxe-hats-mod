using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class TigerHat
    {
        public const string Name = "Tiger Hat";
        public const string Description = "Gain the Tiger's Prowess Buff:\n+3 Attack, +2 Speed, +1 Defense";

        public static void Activate()
        {
            var effects = new BuffEffects();
            effects.Attack.Set(3);
            effects.Speed.Set(2);
            effects.Defense.Set(1);

            var buff = new Buff(
                id: HatService.BuffId,
                source: "Deluxe Hats",
                displaySource: Name,
                displayName: "Tiger's Prowess",
                effects: effects
            );
            buff.description = "Tiger's Prowess\n+3 Attack\n+2 Speed\n+1 Defense";
            buff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
            HatService.CurrentPlayer.applyBuff(buff);

            HatService.OnTimeChanged = (e) =>
            {
                Buff tigerBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (tigerBuff != null)
                {
                    tigerBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                }
            };
        }

        public static void Disable()
        {
            Buff tigerBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (tigerBuff != null)
            {
                tigerBuff.millisecondsDuration = 0;
            }
        }
    }
}
