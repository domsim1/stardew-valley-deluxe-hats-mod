using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class WarriorHelmet
    {
        public const string Name = "Warrior Helmet";
        public const string Description = "Gain the Battle Hardened Buff:\n+4 Defense, +3 Attack";

        public static void Activate()
        {
            var effects = new BuffEffects();
            effects.Defense.Set(4);
            effects.Attack.Set(3);

            var buff = new Buff(
                id: HatService.BuffId,
                source: "Deluxe Hats",
                displaySource: Name,
                displayName: "Battle Hardened",
                effects: effects
            );
            buff.description = "Battle Hardened\n+4 Defense\n+3 Attack";
            buff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
            HatService.CurrentPlayer.applyBuff(buff);

            HatService.OnTimeChanged = (e) =>
            {
                Buff warriorBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (warriorBuff != null)
                {
                    warriorBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                }
            };
        }

        public static void Disable()
        {
            Buff warriorBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (warriorBuff != null)
            {
                warriorBuff.millisecondsDuration = 0;
            }
        }
    }
}
