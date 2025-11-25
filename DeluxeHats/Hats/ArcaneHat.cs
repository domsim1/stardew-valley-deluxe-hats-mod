using StardewValley;
using StardewValley.Buffs;
using System;
using System.Linq;

namespace DeluxeHats.Hats
{
    public static class ArcaneHat
    {
        public const string Name = "Arcane Hat";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff arcaneBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (arcaneBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.LuckLevel.Set(2);
                    effects.Speed.Set(2);
                    effects.Attack.Set(1);
                    arcaneBuff = new Buff(
                        id: HatService.BuffId,
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.arcane-hat.name"),
                        displayName: HatService.GetTranslation("hat.arcane-hat.buff.name"),
                        effects: effects
                        );
                    arcaneBuff.description = HatService.GetTranslation("hat.arcane-hat.buff.description");
                    arcaneBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(arcaneBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff arcaneBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (arcaneBuff != null)
            {
                arcaneBuff.millisecondsDuration = 0;
            }
        }
    }
}
