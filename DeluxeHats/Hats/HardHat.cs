using StardewValley;
using StardewValley.Buffs;
using System;
using System.Linq;

namespace DeluxeHats.Hats
{
    public static class HardHat
    {
        public const string Name = "Hard Hat";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff hardHatBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (hardHatBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.Defense.Set(3);
                    effects.Immunity.Set(1);
                    hardHatBuff = new Buff(
                        id: HatService.BuffId,
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.hard-hat.name"),
                        displayName: HatService.GetTranslation("hat.hard-hat.buff.name"),
                        effects: effects
                        );
                    hardHatBuff.description = HatService.GetTranslation("hat.hard-hat.buff.description");
                    hardHatBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(hardHatBuff);
                }
            };
        }

        public static void Disable()
        {
            if (HatService.CurrentPlayer == null) return;

            Buff hardHatBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (hardHatBuff != null)
            {
                hardHatBuff.millisecondsDuration = 0;
            }
        }
    }
}
