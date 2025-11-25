using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class MushroomCap
    {
        public const string Name = "Mushroom Cap";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff mushroomBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (mushroomBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.ForagingLevel.Set(2);
                    mushroomBuff = new Buff(
                        id: HatService.BuffId,
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.mushroom-cap.name"),
                        displayName: HatService.GetTranslation("hat.mushroom-cap.buff.name"),
                        effects: effects
                        );
                    mushroomBuff.description = HatService.GetTranslation("hat.mushroom-cap.buff.description");
                    mushroomBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(mushroomBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff mushroomBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (mushroomBuff != null)
            {
                mushroomBuff.millisecondsDuration = 0;
            }
        }
    }
}
