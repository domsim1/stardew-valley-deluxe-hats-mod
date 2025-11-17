using Microsoft.Xna.Framework;
using StardewValley;
using StardewValley.Projectiles;
using System.Collections.Generic;

namespace DeluxeHats.Hats
{
    public static class SkeletonMask
    {
        public const string Name = "Skeleton Mask";
        public const string Description = "Shoot out bones when you get hit that deal 40 damage on impact.";
        private static Dictionary<long, int> playerOldHP = new Dictionary<long, int>();

        public static void Activate()
        {
            long playerId = HatService.CurrentPlayer.UniqueMultiplayerID;
            if (!playerOldHP.ContainsKey(playerId))
            {
                playerOldHP[playerId] = HatService.CurrentPlayer.health;
            }

            HatService.OnUpdateTicked = (e) =>
            {
                if (playerOldHP.TryGetValue(HatService.CurrentPlayer.UniqueMultiplayerID, out int oldHP) && oldHP > HatService.CurrentPlayer.health)
                {
                    // Player took damage, shoot bones
                    Game1.currentLocation.projectiles.Add(new BasicProjectile(40, 4, 0, 0, 0.202f, 10, 10, new Vector2(HatService.CurrentPlayer.Position.X, HatService.CurrentPlayer.Position.Y - 32), "skeletonHit", "skeletonStep"));
                    Game1.currentLocation.projectiles.Add(new BasicProjectile(40, 4, 0, 0, 0.202f, -10, 10, new Vector2(HatService.CurrentPlayer.Position.X, HatService.CurrentPlayer.Position.Y - 32), "skeletonHit", "skeletonStep"));
                    Game1.currentLocation.projectiles.Add(new BasicProjectile(40, 4, 0, 0, 0.202f, 10, -10, new Vector2(HatService.CurrentPlayer.Position.X, HatService.CurrentPlayer.Position.Y - 32), "skeletonHit", "skeletonStep"));
                    Game1.currentLocation.projectiles.Add(new BasicProjectile(40, 4, 0, 0, 0.202f, -10, -10, new Vector2(HatService.CurrentPlayer.Position.X, HatService.CurrentPlayer.Position.Y - 32), "skeletonHit", "skeletonStep"));
                }
                playerOldHP[HatService.CurrentPlayer.UniqueMultiplayerID] = HatService.CurrentPlayer.health;
            };
        }

        public static void Disable()
        {
            if (HatService.CurrentPlayer != null)
            {
                playerOldHP.Remove(HatService.CurrentPlayer.UniqueMultiplayerID);
            }
        }
    }
}
