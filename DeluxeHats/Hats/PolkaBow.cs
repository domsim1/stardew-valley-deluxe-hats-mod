using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class PolkaBow
    {
        public const string Name = "Polka Bow";
        public const string Description = "Gain the Polka Dancer Buff:\n+1 Speed";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff polkaBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
                if (polkaBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.Speed.Set(1);
                    polkaBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Polka Dancer",
                        effects: effects
                        );
                    polkaBuff.description = "Polka Dancer\n+1 Speed";
                    polkaBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(polkaBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff polkaBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
            if (polkaBuff != null)
            {
                polkaBuff.millisecondsDuration = 0;
            }
        }
    }
}
