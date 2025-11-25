using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class MagicTurban
    {
        public const string Name = "Magic Turban";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff magicTurbanBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (magicTurbanBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.LuckLevel.Set(2);
                    effects.ForagingLevel.Set(2);
                    magicTurbanBuff = new Buff(
                        id: HatService.BuffId,
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.magic-turban.name"),
                        displayName: HatService.GetTranslation("hat.magic-turban.buff.name"),
                        effects: effects
                        );
                    magicTurbanBuff.description = HatService.GetTranslation("hat.magic-turban.buff.description");
                    magicTurbanBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(magicTurbanBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff magicTurbanBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (magicTurbanBuff != null)
            {
                magicTurbanBuff.millisecondsDuration = 0;
            }
        }
    }
}
