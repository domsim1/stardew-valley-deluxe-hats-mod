using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class EyePatch
    {
        public const string Name = "Eye Patch";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff pirateBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (pirateBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.Attack.Set(1);
                    pirateBuff = new Buff(
                        id: HatService.BuffId,
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.eye-patch.name"),
                        displayName: HatService.GetTranslation("hat.eye-patch.buff.name"),
                        effects: effects
                        );
                    pirateBuff.description = HatService.GetTranslation("hat.eye-patch.buff.description");
                    pirateBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(pirateBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff pirateBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (pirateBuff != null)
            {
                pirateBuff.millisecondsDuration = 0;
            }
        }
    }
}
