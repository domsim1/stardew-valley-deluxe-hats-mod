using System;
using System.Linq;
using StardewValley;

namespace DeluxeHats.Hats
{
    public static class StrawHat
    {
        public const string Name = "Straw Hat";
        public static void Activate()
        {
            HatService.OnDayStarted = (e) =>
            {
                if (Game1.isRaining || Game1.IsWinter)
                {
                    return;
                }
                Buff farmingBuff = Game1.buffsDisplay.otherBuffs.FirstOrDefault(x => x.which == 6284);
                if (farmingBuff == null)
                {
                    farmingBuff = new Buff(
                        farming: 3, 
                        fishing: 0,
                        mining: 0,
                        digging: 0,
                        luck: 0,
                        foraging: 0,
                        crafting: 0,
                        maxStamina: 50, 
                        magneticRadius: 0,
                        speed: 0,
                        defense: 0, 
                        attack: 0, 
                        minutesDuration: 1,
                        source: "Deluxe Hats",
                        displaySource: Name)
                    {
                        which = 6284,
                    };
                    Game1.buffsDisplay.addOtherBuff(farmingBuff);
                    farmingBuff.description = "Dawn Farming\n+3 Farming\n+50 Max Energy";
                    farmingBuff.millisecondsDuration = 129000;
                    Game1.player.stamina += 50;
                }
            };
        }

        public static void Disable()
        {
            Buff farmingBuff = Game1.buffsDisplay.otherBuffs.FirstOrDefault(x => x.which == 6284);
            if (farmingBuff != null)
            {
                farmingBuff.millisecondsDuration = 0;
            }
        }
    }
}
