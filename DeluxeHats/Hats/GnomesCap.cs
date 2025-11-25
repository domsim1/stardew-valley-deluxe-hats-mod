using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class GnomesCap
    {
        public const string Name = "Gnome's Cap";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff gnomeBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (gnomeBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.LuckLevel.Set(1);
                    effects.MiningLevel.Set(1);
                    gnomeBuff = new Buff(
                        id: HatService.BuffId,
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.gnomes-cap.name"),
                        displayName: HatService.GetTranslation("hat.gnomes-cap.buff.name"),
                        effects: effects
                        );
                    gnomeBuff.description = HatService.GetTranslation("hat.gnomes-cap.buff.description");
                    gnomeBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(gnomeBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff gnomeBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (gnomeBuff != null)
            {
                gnomeBuff.millisecondsDuration = 0;
            }
        }
    }
}
