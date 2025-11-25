using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class HairBone
    {
        public const string Name = "Hair Bone";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff boneBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (boneBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.Attack.Set(2);
                    boneBuff = new Buff(
                        id: HatService.BuffId,
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.hair-bone.name"),
                        displayName: HatService.GetTranslation("hat.hair-bone.buff.name"),
                        effects: effects
                        );
                    boneBuff.description = HatService.GetTranslation("hat.hair-bone.buff.description");
                    boneBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(boneBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff boneBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (boneBuff != null)
            {
                boneBuff.millisecondsDuration = 0;
            }
        }
    }
}
