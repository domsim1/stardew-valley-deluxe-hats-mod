using StardewValley;
using StardewValley.Buffs;
using System;
using System.Linq;

namespace DeluxeHats.Hats
{
    public static class Fedora
    {
        public const string Name = "Fedora";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                if (HatService.CurrentPlayer?.currentLocation?.Name == null)
                    return;
                Buff luckBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (!HatService.CurrentPlayer.currentLocation.Name.Contains("Mine"))
                {
                    if (luckBuff != null)
                    {
                        luckBuff.millisecondsDuration = 0;
                    }
                    return;
                }
                if (luckBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.LuckLevel.Set(2);
                    luckBuff = new Buff(
                        id: HatService.BuffId,
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.fedora.name"),
                        displayName: HatService.GetTranslation("hat.fedora.buff.name"),
                        effects: effects
                        );
                    luckBuff.description = HatService.GetTranslation("hat.fedora.buff.description");
                    luckBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(luckBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff luckBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (luckBuff != null)
            {
                luckBuff.millisecondsDuration = 0;
            }
        }
    }
}
