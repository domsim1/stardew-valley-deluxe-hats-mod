using StardewValley;
using StardewValley.Buffs;
using System.Collections.Generic;
using System.Linq;

namespace DeluxeHats.Hats
{
    public static class MouseEars
    {
        public const string Name = "Mouse Ears";
        public const string Description = "When you are hit gain Skittish Mouse Buff:\n+4 Speed";
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
                    Buff mouseBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
                    if (mouseBuff == null)
                    {
                        var effects = new BuffEffects();
                        effects.Speed.Set(4);
                        mouseBuff = new Buff(
                            id: HatService.BuffId,
                            source: "Deluxe Hats",
                            displaySource: Name,
                            displayName: "Skittish Mouse",
                            effects: effects
                            );
                        mouseBuff.description = "Skittish Mouse\n+4 Speed";
                        mouseBuff.millisecondsDuration = 1500;
                        HatService.CurrentPlayer.applyBuff(mouseBuff);
                    }
                    else
                    {
                        mouseBuff.millisecondsDuration = 1500;
                    }
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
            Buff mouseBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
            if (mouseBuff != null)
            {
                mouseBuff.millisecondsDuration = 0;
            }
        }
    }
}
