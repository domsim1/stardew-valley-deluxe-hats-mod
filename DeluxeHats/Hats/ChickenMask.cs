using StardewValley;
using System;
using System.Linq;
using StardewModdingAPI;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class ChickenMask
    {
        public const string Name = "Chicken Mask";
        private const int friendshipPerDay = 15;

        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff chickenBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (chickenBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.FarmingLevel.Set(2);
                    chickenBuff = new Buff(
                        id: HatService.BuffId,
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.chicken-mask.name"),
                        displayName: HatService.GetTranslation("hat.chicken-mask.buff.name"),
                        effects: effects
                        );
                    chickenBuff.description = HatService.GetTranslation("hat.chicken-mask.buff.description");
                    chickenBuff.millisecondsDuration = HatService.GetBuffDuration(20f);
                    HatService.CurrentPlayer.applyBuff(chickenBuff);
                }
            };

            HatService.OnDayStarted = (e) =>
            {
                // Animals are synced from the host, so only the host applies the bonus.
                if (!Context.IsMainPlayer || !Game1.getOnlineFarmers().Contains(HatService.CurrentPlayer))
                    return;
                Utility.ForEachLocation(location =>
                {
                    foreach (FarmAnimal animal in location.animals.Values)
                    {
                        animal.friendshipTowardFarmer.Value = Math.Min(1000, animal.friendshipTowardFarmer.Value + friendshipPerDay);
                    }
                    return true;
                });
            };
        }

        public static void Disable()
        {
            Buff chickenBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (chickenBuff != null)
            {
                chickenBuff.millisecondsDuration = 0;
            }
        }
    }
}
