using StardewValley;
using StardewValley.Buffs;
using System;
using System.Linq;

namespace DeluxeHats.Hats
{
    public static class CowboyHat
    {
        public const string Name = "Cowboy Hat";
        public const string Description = "While riding the horse gain the Buckeroo Buff:\n+2 Speed";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff horseBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
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
                }
                else
                {
                    if (horseBuff != null)
                    {
                        horseBuff.millisecondsDuration = 0;
                    }
                }
            };
        }

        public static void Disable()
        {
            Buff horseBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (horseBuff != null)
            {
                horseBuff.millisecondsDuration = 0;
            }
        }
    }
}
