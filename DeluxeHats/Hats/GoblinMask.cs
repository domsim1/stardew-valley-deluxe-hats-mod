using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class GoblinMask
    {
        public const string Name = "Goblin Mask";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff goblinBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (goblinBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.Attack.Set(2);
                    goblinBuff = new Buff(
                        id: HatService.BuffId,
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.goblin-mask.name"),
                        displayName: HatService.GetTranslation("hat.goblin-mask.buff.name"),
                        effects: effects
                        );
                    goblinBuff.description = HatService.GetTranslation("hat.goblin-mask.buff.description");
                    goblinBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(goblinBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff goblinBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (goblinBuff != null)
            {
                goblinBuff.millisecondsDuration = 0;
            }
        }
    }
}
