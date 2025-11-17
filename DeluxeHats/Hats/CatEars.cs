using System.Collections.Generic;
using System.Linq;
using StardewValley;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class CatEars
    {
        public const string Name = "Cat Ears";
        public const string Description = "When you are hit, meow and gain Skittish Kitty Buff:\n+3 Speed\n+2 Attack";
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
                    Game1.playSound("cat");
                    Buff catBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                    if (catBuff == null)
                    {
                        var effects = new BuffEffects();
                        effects.Speed.Set(3);
                        effects.Attack.Set(2);
                        catBuff = new Buff(
                            id: HatService.BuffId,
                            source: "Deluxe Hats",
                            displaySource: Name,
                            displayName: "Skittish Kitty",
                            effects: effects
                            );
                        catBuff.description = "Skittish Kitty\n+3 Speed\n+2 Attack";
                        catBuff.millisecondsDuration = 1500;
                        HatService.CurrentPlayer.applyBuff(catBuff);
                    }
                    else
                    {
                        catBuff.millisecondsDuration = 1500;
                    }
                }
                playerOldHP[HatService.CurrentPlayer.UniqueMultiplayerID] = HatService.CurrentPlayer.health;
            };
        }

        public static void Disable()
        {
            if (HatService.CurrentPlayer == null) return;

            playerOldHP.Remove(HatService.CurrentPlayer.UniqueMultiplayerID);

            Buff catBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (catBuff != null)
            {
                catBuff.millisecondsDuration = 0;
            }
        }
    }
}
