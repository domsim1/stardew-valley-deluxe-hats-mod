using HarmonyLib;
using StardewValley;
using StardewValley.Buffs;
using System.Collections.Generic;
using System.Linq;

namespace DeluxeHats.Hats
{
    public static class MouseEars
    {
        public const string Name = "Mouse Ears";
        public const string Description = "When you are hit gain Skittish Mouse Buff:\n+4 Speed";
        public static int PlayerOldHP = 0;
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                if (PlayerOldHP > Game1.player.health)
                {
                    Buff mouseBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
                    if (mouseBuff == null)
                    {
                        var effects = new BuffEffects();
                        effects.Speed.Set(4);
                        mouseBuff = new Buff(
                            id: HatService.BuffId,
                            source: "Deluxe Hats",
                            displaySource: Name,
                            displayName: "Skittish Mouse",
                            effects: effects
                            );
                        mouseBuff.description = "Skittish Mouse\n+4 Speed";
                        Game1.buffsDisplay.GetSortedBuffs().AddItem(mouseBuff);
                    }
                    mouseBuff.millisecondsDuration = 1500;
                }
                PlayerOldHP = Game1.player.health;
            };
        }

        public static void Disable()
        {
            PlayerOldHP = 0;
            Buff mouseBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
            if (mouseBuff != null)
            {
                mouseBuff.millisecondsDuration = 0;
            }
        }
    }
}
