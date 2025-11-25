using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class Tropiclip
    {
        public const string Name = "Tropiclip";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff tropiclipBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (tropiclipBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.FarmingLevel.Set(2);
                    effects.LuckLevel.Set(1);
                    tropiclipBuff = new Buff(
                        id: HatService.BuffId,
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.tropiclip.name"),
                        displayName: HatService.GetTranslation("hat.tropiclip.buff.name"),
                        effects: effects
                        );
                    tropiclipBuff.description = HatService.GetTranslation("hat.tropiclip.buff.description");
                    tropiclipBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(tropiclipBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff tropiclipBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (tropiclipBuff != null)
            {
                tropiclipBuff.millisecondsDuration = 0;
            }
        }
    }
}
