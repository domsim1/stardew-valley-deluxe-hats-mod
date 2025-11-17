using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class SpottedHeadscarf
    {
        public const string Name = "Spotted Headscarf";
        public const string Description = "Gain the Spotted Grace Buff:\n+1 Luck";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff spottedBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (spottedBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.LuckLevel.Set(1);
                    spottedBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Spotted Grace",
                        effects: effects
                        );
                    spottedBuff.description = "Spotted Grace\n+1 Luck";
                    spottedBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(spottedBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff spottedBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (spottedBuff != null)
            {
                spottedBuff.millisecondsDuration = 0;
            }
        }
    }
}
