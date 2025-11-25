using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class GarbageHat
    {
        public const string Name = "Garbage Hat";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff garbageBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (garbageBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.ForagingLevel.Set(3);
                    garbageBuff = new Buff(
                        id: HatService.BuffId,
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.garbage-hat.name"),
                        displayName: HatService.GetTranslation("hat.garbage-hat.buff.name"),
                        effects: effects
                        );
                    garbageBuff.description = HatService.GetTranslation("hat.garbage-hat.buff.description");
                    garbageBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(garbageBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff garbageBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (garbageBuff != null)
            {
                garbageBuff.millisecondsDuration = 0;
            }
        }
    }
}
