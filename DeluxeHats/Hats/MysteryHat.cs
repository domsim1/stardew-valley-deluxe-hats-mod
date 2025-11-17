using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class MysteryHat
    {
        public const string Name = "Mystery Hat";
        public const string Description = "Gain the Enigmatic Aura Buff:\n+2 Luck, +1 Farming, +1 Fishing, +1 Mining";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff buff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (buff == null)
                {
                    var effects = new BuffEffects();
                    effects.LuckLevel.Set(2);
                    effects.FarmingLevel.Set(1);
                    effects.FishingLevel.Set(1);
                    effects.MiningLevel.Set(1);
                    buff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Enigmatic Aura",
                        effects: effects
                        );
                    buff.description = "Enigmatic Aura\n+2 Luck, +1 Farming, +1 Fishing, +1 Mining";
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
