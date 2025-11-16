using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class GoblinMask
    {
        public const string Name = "Goblin Mask";
        public const string Description = "Gain the Mischievous Buff:\n+2 Attack";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff goblinBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
                if (goblinBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.Attack.Set(2);
                    goblinBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Mischievous",
                        effects: effects
                        );
                    goblinBuff.description = "Mischievous\n+2 Attack";
                    goblinBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    Game1.player.applyBuff(goblinBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff goblinBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
            if (goblinBuff != null)
            {
                goblinBuff.millisecondsDuration = 0;
            }
        }
    }
}
