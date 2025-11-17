using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class MagicTurban
    {
        public const string Name = "Magic Turban";
        public const string Description = "Gain the Mystic Buff:\n+2 Luck\n+2 Foraging";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff magicTurbanBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
                if (magicTurbanBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.LuckLevel.Set(2);
                    effects.ForagingLevel.Set(2);
                    magicTurbanBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Mystic",
                        effects: effects
                        );
                    magicTurbanBuff.description = "Mystic\n+2 Luck\n+2 Foraging";
                    magicTurbanBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(magicTurbanBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff magicTurbanBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
            if (magicTurbanBuff != null)
            {
                magicTurbanBuff.millisecondsDuration = 0;
            }
        }
    }
}
