using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class ElegantTurban
    {
        public const string Name = "Elegant Turban";
        public const string Description = "Gain the Posh Buff:\n+2 Luck";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff elegantBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (elegantBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.LuckLevel.Set(2);
                    elegantBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Posh",
                        effects: effects
                        );
                    elegantBuff.description = "Posh\n+2 Luck";
                    elegantBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(elegantBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff elegantBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (elegantBuff != null)
            {
                elegantBuff.millisecondsDuration = 0;
            }
        }
    }
}
