using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class CopperPan
    {
        public const string Name = "Copper Pan";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff copperBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (copperBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.MiningLevel.Set(2);
                    copperBuff = new Buff(
                        id: HatService.BuffId,
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.copper-pan.name"),
                        displayName: HatService.GetTranslation("hat.copper-pan.buff.name"),
                        effects: effects
                        );
                    copperBuff.description = HatService.GetTranslation("hat.copper-pan.buff.description");
                    copperBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(copperBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff copperBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (copperBuff != null)
            {
                copperBuff.millisecondsDuration = 0;
            }
        }
    }
}
