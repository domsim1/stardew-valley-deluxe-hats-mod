using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class Sombrero
    {
        public const string Name = "Sombrero";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff sombruroBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (sombruroBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.LuckLevel.Set(2);
                    sombruroBuff = new Buff(
                        id: HatService.BuffId,
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.sombrero.name"),
                        displayName: HatService.GetTranslation("hat.sombrero.buff.name"),
                        effects: effects
                        );
                    sombruroBuff.description = HatService.GetTranslation("hat.sombrero.buff.description");
                    sombruroBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(sombruroBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff sombruroBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (sombruroBuff != null)
            {
                sombruroBuff.millisecondsDuration = 0;
            }
        }
    }
}
