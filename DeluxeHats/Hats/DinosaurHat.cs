using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class DinosaurHat
    {
        public const string Name = "Dinosaur Hat";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff dinooBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (dinooBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.Attack.Set(3);
                    dinooBuff = new Buff(
                        id: HatService.BuffId,
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.dinosaur-hat.name"),
                        displayName: HatService.GetTranslation("hat.dinosaur-hat.buff.name"),
                        effects: effects
                        );
                    dinooBuff.description = HatService.GetTranslation("hat.dinosaur-hat.buff.description");
                    dinooBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(dinooBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff dinooBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (dinooBuff != null)
            {
                dinooBuff.millisecondsDuration = 0;
            }
        }
    }
}
