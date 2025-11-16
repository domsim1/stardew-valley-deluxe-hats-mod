using System.Linq;
using HarmonyLib;
using StardewValley;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class CatEars
    {
        public const string Name = "Cat Ears";
        public const string Description = "When you are hit, meow and gain Skittish Kitty Buff:\n+3 Speed\n+2 Attack";
        public static int PlayerOldHP = 0;
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                if (PlayerOldHP > Game1.player.health)
                {
                    Game1.playSound("cat");
                    Buff catBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
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
                        Game1.buffsDisplay.GetSortedBuffs().AddItem(catBuff);
                    }
                    catBuff.millisecondsDuration = 1500;
                }
                PlayerOldHP = Game1.player.health;
            };
        }

        public static void Disable()
        {
            PlayerOldHP = 0;
            Buff catBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
            if (catBuff != null)
            {
                catBuff.millisecondsDuration = 0;
            }
        }
    }
}
