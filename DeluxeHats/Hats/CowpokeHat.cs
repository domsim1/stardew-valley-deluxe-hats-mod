using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class CowpokeHat
    {
        public const string Name = "Cowpoke Hat";
        public const string Description = "While riding the horse gain the Buckeroo Buff:\n+1 Speed";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff cowpokeBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
                if (Game1.player.isRidingHorse())
                {
                    if (cowpokeBuff == null)
                    {
                        var effects = new BuffEffects();
                        effects.Speed.Set(1);
                        cowpokeBuff = new Buff(
                            id: HatService.BuffId,
                            source: "Deluxe Hats",
                            displaySource: Name,
                            displayName: "Buckeroo",
                            effects: effects
                            );
                        cowpokeBuff.description = "Buckeroo\n+1 Speed";
                        cowpokeBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                        Game1.player.applyBuff(cowpokeBuff);
                    }
                }
                else
                {
                    if (cowpokeBuff != null)
                    {
                        cowpokeBuff.millisecondsDuration = 0;
                    }
                }
            };
        }

        public static void Disable()
        {
            Buff cowpokeBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
            if (cowpokeBuff != null)
            {
                cowpokeBuff.millisecondsDuration = 0;
            }
        }
    }
}
