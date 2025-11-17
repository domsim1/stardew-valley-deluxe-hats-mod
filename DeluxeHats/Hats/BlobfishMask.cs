using StardewValley;
using StardewValley.Buffs;
using System;
using System.Linq;

namespace DeluxeHats.Hats
{
    public static class BlobfishMask
    {
        public const string Name = "Blobfish Mask";
        public const string Description = "While fishing at night gain the Deep Sea Treasure Buff:\n+3 Fishing, +2 Luck";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff blobfishBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (Game1.timeOfDay >= 1800)
                {
                    if (blobfishBuff == null)
                    {
                        var effects = new BuffEffects();
                        effects.FishingLevel.Set(3);
                        effects.LuckLevel.Set(2);
                        blobfishBuff = new Buff(
                            id: HatService.BuffId,
                            source: "Deluxe Hats",
                            displaySource: Name,
                            displayName: "Deep Sea Treasure",
                            effects: effects
                            );
                        blobfishBuff.description = "Deep Sea Treasure\n+3 Fishing, +2 Luck";
                        blobfishBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                        HatService.CurrentPlayer.applyBuff(blobfishBuff);
                    }
                }
                else
                {
                    if (blobfishBuff != null)
                    {
                        blobfishBuff.millisecondsDuration = 0;
                    }
                }
            };
        }

        public static void Disable()
        {
            Buff blobfishBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (blobfishBuff != null)
            {
                blobfishBuff.millisecondsDuration = 0;
            }
        }
    }
}
