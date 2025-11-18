using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class PandaHat
    {
        public const string Name = "Panda Hat";
        public const string Description = "Gain the Bamboo Muncher Buff:\n+3 Farming";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff pandaBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (pandaBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.FarmingLevel.Set(3);
                    pandaBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Bamboo Muncher",
                        effects: effects
                        );
                    pandaBuff.description = "Bamboo Muncher\n+3 Farming";
                    pandaBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(pandaBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff pandaBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (pandaBuff != null)
            {
                pandaBuff.millisecondsDuration = 0;
            }
        }
    }
}
