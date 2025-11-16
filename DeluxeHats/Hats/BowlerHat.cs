using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class BowlerHat
    {
        public const string Name = "Bowler Hat";
        public const string Description = "Gain the Dapper Buff:\n+1 Defense";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff bowlerBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
                if (bowlerBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.Defense.Set(1);
                    bowlerBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Dapper",
                        effects: effects
                        );
                    bowlerBuff.description = "Dapper\n+1 Defense";
                    bowlerBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    Game1.player.applyBuff(bowlerBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff bowlerBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
            if (bowlerBuff != null)
            {
                bowlerBuff.millisecondsDuration = 0;
            }
        }
    }
}
