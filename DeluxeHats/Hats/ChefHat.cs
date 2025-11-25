using StardewValley;
using StardewValley.Buffs;
using System;
using System.Linq;

namespace DeluxeHats.Hats
{
    public static class ChefHat
    {
        public const string Name = "Chef Hat";
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
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.chef-hat.name"),
                        displayName: HatService.GetTranslation("hat.chef-hat.buff.name"),
                        effects: effects
                        );
                    chefBuff.description = HatService.GetTranslation("hat.chef-hat.buff.description");
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