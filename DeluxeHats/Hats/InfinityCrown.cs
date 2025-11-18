using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class InfinityCrown
    {
        public const string Name = "Infinity Crown";
        public const string Description = "Gain the Infinite Power Buff:\n+4 Farming, +4 Mining, +4 Fishing, +3 Luck";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff buff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (buff == null)
                {
                    var effects = new BuffEffects();
                    effects.FarmingLevel.Set(4);
                    effects.MiningLevel.Set(4);
                    effects.FishingLevel.Set(4);
                    effects.LuckLevel.Set(3);
                    buff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Infinite Power",
                        effects: effects
                        );
                    buff.description = "Infinite Power\n+4 Farming, +4 Mining, +4 Fishing, +3 Luck";
                    buff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(buff);
                }
            };
        }

        public static void Disable()
        {
            Buff buff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (buff != null)
            {
                buff.millisecondsDuration = 0;
            }
        }
    }
}
