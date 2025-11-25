using System.Collections.Generic;
using System.Linq;
using StardewValley;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class CatEars
    {
        public const string Name = "Cat Ears";
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
                            source: HatService.GetTranslation("mod.name"),
                            displaySource: HatService.GetTranslation("hat.cat-ears.name"),
                            displayName: HatService.GetTranslation("hat.cat-ears.buff.name"),
                            effects: effects
                            );
                        catBuff.description = HatService.GetTranslation("hat.cat-ears.buff.description");
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
