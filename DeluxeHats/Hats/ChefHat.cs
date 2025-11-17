using StardewValley;
using StardewValley.Buffs;
using System.Linq;

namespace DeluxeHats.Hats
{
    public static class ChefHat
    {
        public const string Name = "Chef Hat";
        public const string Description = "Double the buff from eating food.";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                // Replace Game1.buffsDisplay.food with a call to get the food buff
                Buff foodBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.source == "food");
                if (foodBuff == null)
                {
                    return;
                }
                Buff chefBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
                if (HatService.CurrentPlayer.isEating)
                {
                    if (chefBuff != null)
                    {
                        chefBuff.millisecondsDuration = 0;
                    }
                    return;
                }
                if (chefBuff == null)
                {
                    var foodAttributes = HatService.Helper.Reflection.GetField<int[]>(foodBuff, "buffAttributes").GetValue();
                    var effects = new BuffEffects();
                    effects.FarmingLevel.Set(foodAttributes[0]);
                    effects.FishingLevel.Set(foodAttributes[1]);
                    effects.MiningLevel.Set(foodAttributes[2]);
                    // skipping digging/luck mapping not present in BuffEffects directly
                    effects.LuckLevel.Set(foodAttributes[4]);
                    effects.ForagingLevel.Set(foodAttributes[5]);
                    effects.MaxStamina.Set(foodAttributes[7]);
                    effects.MagneticRadius.Set(foodAttributes[8]);
                    effects.Speed.Set(foodAttributes[9]);
                    effects.Defense.Set(foodAttributes[10]);
                    effects.Attack.Set(foodAttributes[11]);

                    chefBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Head Chef",
                        effects: effects
                        );
                    chefBuff.description = $"Head Chef\nx2 {foodBuff.displaySource}";
                    chefBuff.millisecondsDuration = foodBuff.millisecondsDuration;
                    HatService.CurrentPlayer.applyBuff(chefBuff);
                }
                else
                {
                    chefBuff.millisecondsDuration = foodBuff.millisecondsDuration;
                }
            };
        }

        public static void Disable()
        {
            Buff chefBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
            if (chefBuff != null)
            {
                chefBuff.millisecondsDuration = 0;
            }
        }
    }
}