using StardewValley;
using StardewValley.Buffs;
using System;
using System.Linq;

namespace DeluxeHats.Hats
{
    public static class DelicateBow
    {
        public const string Name = "Delicate Bow";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff delicateBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (delicateBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.LuckLevel.Set(2);
                    effects.Speed.Set(1);
                    delicateBuff = new Buff(
                        id: HatService.BuffId,
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.delicate-bow.name"),
                        displayName: HatService.GetTranslation("hat.delicate-bow.buff.name"),
                        effects: effects
                        );
                    delicateBuff.description = HatService.GetTranslation("hat.delicate-bow.buff.description");
                    delicateBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(delicateBuff);
                }
            };
        }

        public static void Disable()
        {
            if (HatService.CurrentPlayer == null) return;

            Buff delicateBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (delicateBuff != null)
            {
                delicateBuff.millisecondsDuration = 0;
            }
        }
    }
}
