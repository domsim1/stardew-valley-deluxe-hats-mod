using StardewValley;
using StardewValley.Buffs;
using System;
using System.Linq;

namespace DeluxeHats.Hats
{
    public static class ChefHat
    {
        public const string Name = "Chef Hat";
        public const string Description = "Gain the Master Chef Buff:\n+2 Farming, +1 Foraging, +1 Fishing";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff chefBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (chefBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.FarmingLevel.Set(2);
                    effects.ForagingLevel.Set(1);
                    effects.FishingLevel.Set(1);
                    chefBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Master Chef",
                        effects: effects
                        );
                    chefBuff.description = "Master Chef\n+2 Farming, +1 Foraging, +1 Fishing";
                    chefBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(chefBuff);
                }
            };
        }

        public static void Disable()
        {
            if (HatService.CurrentPlayer == null) return;

            Buff chefBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (chefBuff != null)
            {
                chefBuff.millisecondsDuration = 0;
            }
        }
    }
}