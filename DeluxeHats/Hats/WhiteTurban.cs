using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class WhiteTurban
    {
        public const string Name = "White Turban";
        public const string Description = "Gain the Sage Buff:\n+2 Foraging";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff turbanBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (turbanBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.ForagingLevel.Set(2);
                    turbanBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Sage",
                        effects: effects
                        );
                    turbanBuff.description = "Sage\n+2 Foraging";
                    turbanBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(turbanBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff turbanBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (turbanBuff != null)
            {
                turbanBuff.millisecondsDuration = 0;
            }
        }
    }
}
