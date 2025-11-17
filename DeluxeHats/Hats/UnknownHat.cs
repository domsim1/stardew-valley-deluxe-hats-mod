using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class UnknownHat
    {
        public const string Name = "???";
        public const string Description = "Gain the Mysterious Power Buff:\n+10 Farming, +10 Fishing, +10 Foraging, +10 Mining, +10 Luck, +5 Speed, +5 Defense, +5 Attack, +5 Immunity";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff unknownBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
                if (unknownBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.FarmingLevel.Set(10);
                    effects.FishingLevel.Set(10);
                    effects.ForagingLevel.Set(10);
                    effects.MiningLevel.Set(10);
                    effects.LuckLevel.Set(10);
                    effects.Speed.Set(5);
                    effects.Defense.Set(5);
                    effects.Attack.Set(5);
                    effects.Immunity.Set(5);
                    unknownBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Mysterious Power",
                        effects: effects
                        );
                    unknownBuff.description = "Mysterious Power\n+10 Farming, +10 Fishing, +10 Foraging, +10 Mining, +10 Luck, +5 Speed, +5 Defense, +5 Attack, +5 Immunity";
                    unknownBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(unknownBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff unknownBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
            if (unknownBuff != null)
            {
                unknownBuff.millisecondsDuration = 0;
            }
        }
    }
}
