using StardewValley;
using StardewValley.Buffs;
using System;
using System.Linq;

namespace DeluxeHats.Hats
{
    public static class Fedora
    {
        public const string Name = "Fedora";
        public const string Description = "When in the Mines or Skull Cavern gain the \"Fortune and glory, kid.\" Buff:\n+2 Luck";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff luckBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
                if (!Game1.currentLocation.name.Value.Contains("Mine"))
                {
                    if (luckBuff != null)
                    {
                        luckBuff.millisecondsDuration = 0;
                    }
                    return;
                }
                if (luckBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.LuckLevel.Set(2);
                    luckBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Fortune and glory",
                        effects: effects
                        );
                    luckBuff.description = "\"Fortune and glory, kid.\"\n+2 Luck";
                    luckBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    Game1.player.applyBuff(luckBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff luckBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
            if (luckBuff != null)
            {
                luckBuff.millisecondsDuration = 0;
            }
        }
    }
}
