using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class GreenTurban
    {
        public const string Name = "Green Turban";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff greenBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (greenBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.LuckLevel.Set(1);
                    effects.ForagingLevel.Set(1);
                    greenBuff = new Buff(
                        id: HatService.BuffId,
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.green-turban.name"),
                        displayName: HatService.GetTranslation("hat.green-turban.buff.name"),
                        effects: effects
                        );
                    greenBuff.description = HatService.GetTranslation("hat.green-turban.buff.description");
                    greenBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(greenBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff greenBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (greenBuff != null)
            {
                greenBuff.millisecondsDuration = 0;
            }
        }
    }
}
