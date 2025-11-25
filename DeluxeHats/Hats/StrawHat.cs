using System;
using System.Linq;
using StardewValley;
using StardewValley.Buffs;
using System.Collections.Generic;

namespace DeluxeHats.Hats
{
    public static class StrawHat
    {
        public const string Name = "Straw Hat";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                if (Game1.isRaining || Game1.IsWinter)
                {
                    return;
                }
                if (Game1.timeOfDay > 930)
                {
                    return;
                }
                Buff farmingBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (farmingBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.FarmingLevel.Set(3);
                    farmingBuff = new Buff(
                        id: HatService.BuffId,
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.straw-hat.name"),
                        displayName: HatService.GetTranslation("hat.straw-hat.buff.name"),
                        effects: effects
                        );
                    farmingBuff.description = HatService.GetTranslation("hat.straw-hat.buff.description");
                    farmingBuff.millisecondsDuration = Convert.ToInt32((3.3f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(farmingBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff farmingBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (farmingBuff != null)
            {
                farmingBuff.millisecondsDuration = 0;
            }
        }
    }
}
