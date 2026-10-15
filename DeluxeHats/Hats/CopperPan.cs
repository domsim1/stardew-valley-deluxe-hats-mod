using StardewValley;
using System;
using System.Linq;
using DeluxeHats.Utils;
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
                    copperBuff.millisecondsDuration = HatService.GetBuffDuration(20f);
                    HatService.CurrentPlayer.applyBuff(copperBuff);
                }

                Prospector.Update(HatService.CurrentPlayer, showDirection: false);
            };
        }

        public static void Disable()
        {
            Prospector.Reset(HatService.CurrentPlayer);
            Buff copperBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (copperBuff != null)
            {
                copperBuff.millisecondsDuration = 0;
            }
        }
    }
}
