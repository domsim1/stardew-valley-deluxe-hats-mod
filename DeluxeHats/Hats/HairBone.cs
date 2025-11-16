using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class HairBone
    {
        public const string Name = "Hair Bone";
        public const string Description = "Gain the Primal Hunter Buff:\n+2 Attack";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff boneBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
                if (boneBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.Attack.Set(2);
                    boneBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Primal Hunter",
                        effects: effects
                        );
                    boneBuff.description = "Primal Hunter\n+2 Attack";
                    boneBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    Game1.player.applyBuff(boneBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff boneBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
            if (boneBuff != null)
            {
                boneBuff.millisecondsDuration = 0;
            }
        }
    }
}
