using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using StardewValley;

namespace DeluxeHats.Utils
{
    /// <summary>Shared "prospector's sense" for the pan hats: notifies the wearer when a panning spot appears.</summary>
    public static class Prospector
    {
        private static readonly Dictionary<long, string> lastNotifiedSpot = new Dictionary<long, string>();

        /// <summary>Call from a pan hat's update tick. Only notifies the local player, once per spot.</summary>
        public static void Update(Farmer player, bool showDirection)
        {
            if (player == null || !player.IsLocalPlayer || player.currentLocation == null || Game1.ticks % 60 != 0)
                return;

            GameLocation location = player.currentLocation;
            Point spot = location.orePanPoint.Value;
            if (spot == Point.Zero)
            {
                lastNotifiedSpot.Remove(player.UniqueMultiplayerID);
                return;
            }

            string spotKey = $"{location.NameOrUniqueName}:{spot.X},{spot.Y}";
            if (lastNotifiedSpot.TryGetValue(player.UniqueMultiplayerID, out string lastKey) && lastKey == spotKey)
                return;
            lastNotifiedSpot[player.UniqueMultiplayerID] = spotKey;

            string direction = showDirection ? GetDirection(player.Tile, spot) : null;
            string message = direction != null
                ? string.Format(HatService.GetTranslation("prospector.found-direction"), direction)
                : HatService.GetTranslation("prospector.found");
            Game1.addHUDMessage(new HUDMessage(message, HUDMessage.newQuest_type));
            Game1.playSound("coin");
        }

        public static void Reset(Farmer player)
        {
            if (player != null)
                lastNotifiedSpot.Remove(player.UniqueMultiplayerID);
        }

        /// <summary>Returns the compass direction to the spot, or null if the player is already next to it.</summary>
        private static string GetDirection(Vector2 from, Point to)
        {
            float dx = to.X - from.X;
            float dy = to.Y - from.Y;
            if (Math.Abs(dx) < 2 && Math.Abs(dy) < 2)
                return null;

            // Screen Y increases downward, so negate it to get a compass angle.
            double angle = Math.Atan2(-dy, dx) * 180 / Math.PI;
            string[] keys = { "east", "north-east", "north", "north-west", "west", "south-west", "south", "south-east" };
            int index = (int)Math.Round(((angle + 360) % 360) / 45) % 8;
            return HatService.GetTranslation($"direction.{keys[index]}");
        }
    }
}
