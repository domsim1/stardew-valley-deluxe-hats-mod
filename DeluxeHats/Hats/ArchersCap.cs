using StardewValley;
using StardewValley.Buffs;
using System;
using System.Linq;

namespace DeluxeHats.Hats
{
    public static class ArchersCap
    {
        public const string Name = "Archer's Cap";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff archerBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (archerBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.Attack.Set(2);
                    effects.Speed.Set(1);
                    effects.Defense.Set(1);
                    archerBuff = new Buff(
                        id: HatService.BuffId,
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.archers-cap.name"),
                        displayName: HatService.GetTranslation("hat.archers-cap.buff.name"),
                        effects: effects
                        );
                    archerBuff.description = HatService.GetTranslation("hat.archers-cap.buff.description");
                    archerBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(archerBuff);
                }
            };
        }

        public static void Disable()
        {
            if (HatService.CurrentPlayer == null) return;

            Buff archerBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (archerBuff != null)
            {
                archerBuff.millisecondsDuration = 0;
            }
        }
    }
}
