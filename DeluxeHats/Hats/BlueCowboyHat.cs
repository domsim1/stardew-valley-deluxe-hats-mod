using StardewValley;
using StardewValley.Buffs;
using System;
using System.Linq;

namespace DeluxeHats.Hats
{
    public static class BlueCowboyHat
    {
        public const string Name = "Blue Cowboy Hat";
        public const string Description = "While riding the horse and for 30 seconds after dismounting gain the Buckeroo Buff:\n+2 Speed";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff horseBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
                if (HatService.CurrentPlayer.isRidingHorse())
                {
                    if (horseBuff == null)
                    {
                        var effects = new BuffEffects();
                        effects.Speed.Set(2);
                        horseBuff = new Buff(
                            id: HatService.BuffId,
                            source: "Deluxe Hats",
                            displaySource: Name,
                            displayName: "Buckeroo",
                            effects: effects
                            );
                        horseBuff.description = "Buckeroo\n+2 Speed";
                        horseBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                        HatService.CurrentPlayer.applyBuff(horseBuff);
                    }
                    if (horseBuff.millisecondsDuration < 30001)
                    {
                        horseBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    }
                }
                else
                {
                    if (horseBuff != null && horseBuff.millisecondsDuration > 30001)
                    {
                        horseBuff.millisecondsDuration = 30000;
                    }
                }
            };
        }

        public static void Disable()
        {
            Buff horseBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
            if (horseBuff != null)
            {
                horseBuff.millisecondsDuration = 0;
            }
        }
    }
}
