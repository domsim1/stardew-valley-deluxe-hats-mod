using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class ConeHat
    {
        public const string Name = "Cone Hat";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff coneBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (coneBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.LuckLevel.Set(1);
                    coneBuff = new Buff(
                        id: HatService.BuffId,
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.cone-hat.name"),
                        displayName: HatService.GetTranslation("hat.cone-hat.buff.name"),
                        effects: effects
                        );
                    coneBuff.description = HatService.GetTranslation("hat.cone-hat.buff.description");
                    coneBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(coneBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff coneBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (coneBuff != null)
            {
                coneBuff.millisecondsDuration = 0;
            }
        }
    }
}
