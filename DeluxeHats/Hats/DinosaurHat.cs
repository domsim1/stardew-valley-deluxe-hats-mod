using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class DinosaurHat
    {
        public const string Name = "Dinosaur Hat";
        public const string Description = "Gain the Ancient Predator Buff:\n+3 Attack";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff dinooBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
                if (dinooBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.Attack.Set(3);
                    dinooBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Ancient Predator",
                        effects: effects
                        );
                    dinooBuff.description = "Ancient Predator\n+3 Attack";
                    dinooBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    Game1.player.applyBuff(dinooBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff dinooBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
            if (dinooBuff != null)
            {
                dinooBuff.millisecondsDuration = 0;
            }
        }
    }
}
