using System;
using System.Collections.Generic;
using StardewValley;
using StardewValley.BellsAndWhistles;

namespace DeluxeHats.Hats
{
    public static class ButterflyBow
    {
        public const string Name = "Butterfly Bow";
        public static void Activate()
        {
            
            HatService.OnUpdateTicked = (e) =>
            {
                if (!Game1.currentLocation.isOutdoors || Game1.player.hasMenuOpen || !Game1.player.canMove || !Game1.game1.IsActive)
                {
                    return;
                }
                var critters = HatService.Helper.Reflection.GetField<List<Critter>>(Game1.currentLocation, "critters").GetValue();
                if (critters != null && (e.Ticks%30) == 0 && critters.Count < 340)
                {
                    critters.Add(new Butterfly(Game1.player.getTileLocation()));
                }
                if (e.Ticks % 480 == 0)
                {
                    foreach (var npc in Game1.currentLocation.getCharacters())
                    {
                        Game1.player.changeFriendship(5, npc);
                    }
                }
                
            };
        }

        public static void Disable()
        {
        }
    }
}
