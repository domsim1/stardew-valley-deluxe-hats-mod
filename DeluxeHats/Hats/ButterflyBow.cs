using System.Collections.Generic;
using Microsoft.Xna.Framework;
using StardewValley;
using StardewValley.BellsAndWhistles;

namespace DeluxeHats.Hats
{
    public static class ButterflyBow
    {
        public const string Name = "Butterfly Bow";
        public const string Description = "Spawns Butterflies around you while outside.\nPeople in the same outdoor area as you will gain 5 friendship every 7 seconds.";
        public static void Activate()
        {
            
            HatService.OnUpdateTicked = (e) =>
            {
                if (!HatService.CurrentPlayer.currentLocation.isOutdoors.Value || HatService.CurrentPlayer.hasMenuOpen.Value || !HatService.CurrentPlayer.canMove || !Game1.game1.IsActive)
                {
                    return;
                }
                var critters = HatService.Helper.Reflection.GetField<List<Critter>>(HatService.CurrentPlayer.currentLocation, "critters").GetValue();
                if (critters != null && (e.Ticks%30) == 0 && critters.Count < 340)
                {
                    var randomX = HatService.CurrentPlayer.position.X + Game1.random.Next(3);
                    var randomY = HatService.CurrentPlayer.position.Y + Game1.random.Next(3);
                    critters.Add(new Butterfly(
                        HatService.CurrentPlayer.currentLocation,
                        new Vector2(randomX, randomY)
                    ));
                }
                if (e.Ticks % 480 == 0)
                {
                    foreach (var npc in HatService.CurrentPlayer.currentLocation.characters)
                    {
                        HatService.CurrentPlayer.changeFriendship(5, npc);
                    }
                }
                
            };
        }

        public static void Disable()
        {
        }
    }
}
