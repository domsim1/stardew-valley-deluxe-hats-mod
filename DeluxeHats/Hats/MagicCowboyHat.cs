using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class MagicCowboyHat
    {
        public const string Name = "Magic Cowboy Hat";
        public const string Description = "While riding the horse gain the Spellslinger Buff:\n+2 Speed\n+1 Attack";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff magicBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
                if (HatService.CurrentPlayer.isRidingHorse())
                {
                    if (magicBuff == null)
                    {
                        var effects = new BuffEffects();
                        effects.Speed.Set(2);
                        effects.Attack.Set(1);
                        magicBuff = new Buff(
                            id: HatService.BuffId,
                            source: "Deluxe Hats",
                            displaySource: Name,
                            displayName: "Spellslinger",
                            effects: effects
                            );
                        magicBuff.description = "Spellslinger\n+2 Speed\n+1 Attack";
                        magicBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                        HatService.CurrentPlayer.applyBuff(magicBuff);
                    }
                }
                else
                {
                    if (magicBuff != null)
                    {
                        magicBuff.millisecondsDuration = 0;
                    }
                }
            };
        }

        public static void Disable()
        {
            Buff magicBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
            if (magicBuff != null)
            {
                magicBuff.millisecondsDuration = 0;
            }
        }
    }
}
