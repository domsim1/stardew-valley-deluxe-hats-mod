using StardewValley;
using StardewValley.Buffs;
using System.Collections.Generic;
using System.Linq;

namespace DeluxeHats.Hats
{
    public static class MouseEars
    {
        public const string Name = "Mouse Ears";
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
                    Buff mouseBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                    if (mouseBuff == null)
                    {
                        var effects = new BuffEffects();
                        effects.Speed.Set(4);
                        mouseBuff = new Buff(
                            id: HatService.BuffId,
                            source: HatService.GetTranslation("mod.name"),
                            displaySource: HatService.GetTranslation("hat.mouse-ears.name"),
                            displayName: HatService.GetTranslation("hat.mouse-ears.buff.name"),
                            effects: effects
                            );
                        mouseBuff.description = HatService.GetTranslation("hat.mouse-ears.buff.description");
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
            if (HatService.CurrentPlayer == null) return;

            playerOldHP.Remove(HatService.CurrentPlayer.UniqueMultiplayerID);

            Buff mouseBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (mouseBuff != null)
            {
                mouseBuff.millisecondsDuration = 0;
            }
        }
    }
}
