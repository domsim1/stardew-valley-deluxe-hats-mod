using System.Linq;
using Microsoft.Xna.Framework;
using StardewValley;
using StardewValley.Buffs;
using System.Collections.Generic;

namespace DeluxeHats.Hats
{
    public static class SailorsCap
    {
        public const string Name = "Sailor's Cap";
        public const string Description = "When tipsy gain the Drunken Sailor Buff:\n+10 Attack";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff tipsyBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.source == "drink");
                if (tipsyBuff != null)
                {
                    Buff powerBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                    if (powerBuff == null)
                    {
                        var effects = new BuffEffects();
                        effects.Attack.Set(10);
                        powerBuff = new Buff(
                            id: HatService.BuffId,
                            source: "Deluxe Hats",
                            displaySource: Name,
                            displayName: "Drunken Sailor",
                            effects: effects
                            );
                        powerBuff.description = "Drunken Sailor\n+10 Attack";
                        HatService.CurrentPlayer.applyBuff(powerBuff);
                        HatService.CurrentPlayer.startGlowing(Color.OrangeRed * 0.5f, false, 0.08f);
                    }
                    powerBuff.millisecondsDuration = tipsyBuff.millisecondsDuration;
                }
                else if (HatService.CurrentPlayer.isGlowing && HatService.CurrentPlayer.glowingColor == Color.OrangeRed * 0.5f)
                {
                    HatService.CurrentPlayer.stopGlowing();
                }
            };
        }

        public static void Disable()
        {
            Buff powerBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (powerBuff != null)
            {
                powerBuff.millisecondsDuration = 0;
            }
        }
    }
}
