using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class QiMask
    {
        public const string Name = "Qi Mask";
        public const string Description = "Gain the Shadowy Power Buff:\n+3 Mining, +3 Attack, +2 Defense";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff buff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
                if (buff == null)
                {
                    var effects = new BuffEffects();
                    effects.MiningLevel.Set(3);
                    effects.Attack.Set(3);
                    effects.Defense.Set(2);
                    buff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Shadowy Power",
                        effects: effects
                        );
                    buff.description = "Shadowy Power\n+3 Mining, +3 Attack, +2 Defense";
                    buff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    Game1.player.applyBuff(buff);
                }
            };
        }

        public static void Disable()
        {
            Buff buff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
            if (buff != null)
            {
                buff.millisecondsDuration = 0;
            }
        }
    }
}
