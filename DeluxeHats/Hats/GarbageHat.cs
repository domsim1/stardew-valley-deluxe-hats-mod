using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class GarbageHat
    {
        public const string Name = "Garbage Hat";
        public const string Description = "Gain the Trash Panda Buff:\n+3 Foraging";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff garbageBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (garbageBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.ForagingLevel.Set(3);
                    garbageBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Trash Panda",
                        effects: effects
                        );
                    garbageBuff.description = "Trash Panda\n+3 Foraging";
                    garbageBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(garbageBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff garbageBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (garbageBuff != null)
            {
                garbageBuff.millisecondsDuration = 0;
            }
        }
    }
}
