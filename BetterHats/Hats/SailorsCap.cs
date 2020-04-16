using System;
using System.Linq;
using Microsoft.Xna.Framework;
using StardewValley;

namespace BetterHats.Hats
{
    public static class SailorsCap
    {
        public const string Name = "Sailor's Cap";
        public static void Activate()
        {
            HatService.OnTickMethod = (e) =>
            {
                Buff tipsyBuff = Game1.buffsDisplay.otherBuffs.FirstOrDefault(x => x.which == Buff.tipsy);
                if (tipsyBuff != null)
                {
                    Buff powerBuff = Game1.buffsDisplay.otherBuffs.FirstOrDefault(x => x.which == 1234);
                    if (powerBuff == null)
                    {
                        powerBuff = new Buff(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, attack: 10, minutesDuration: 1, source: "Delux Hats", displaySource: Name) { which = 1234 };
                        Game1.buffsDisplay.addOtherBuff(powerBuff);
                        Game1.player.startGlowing(Color.OrangeRed * 0.5f, false, 0.08f);
                        powerBuff.description = "Drunken Sailor\n+10 Attack";
                    }
                    powerBuff.millisecondsDuration = tipsyBuff.millisecondsDuration;
                }
                else if (Game1.player.isGlowing && Game1.player.glowingColor == Color.OrangeRed * 0.5f)
                {
                    Game1.player.stopGlowing();
                }
            };
        }

        public static void Disable()
        {
            Buff powerBuff = Game1.buffsDisplay.otherBuffs.FirstOrDefault(x => x.which == 1234);
            if (powerBuff != null)
            {
                powerBuff.millisecondsDuration = 0;
            }
        }
    }
}
