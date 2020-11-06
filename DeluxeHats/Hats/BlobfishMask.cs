using StardewModdingAPI;
using StardewValley;

namespace DeluxeHats.Hats
{
    public static class BlobfishMask
    {
        public const string Name = "Blobfish Mask";
        public const string Description = "Triple the chance to find treasure while fishing at night.";
        private const int blobfishMaskTreasureChanceMultiplyer = 3;
        private static bool isEffectActive = false;
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                if (Game1.timeOfDay < 1800)
                {
                    if (isEffectActive == true)
                    {
                        Disable();
                    }
                    return;
                }
                if (isEffectActive == true)
                {
                    return;
                }
                StardewValley.Tools.FishingRod.baseChanceForTreasure *= blobfishMaskTreasureChanceMultiplyer;
                isEffectActive = true;
            };
        }

        public static void Disable()
        {
            StardewValley.Tools.FishingRod.baseChanceForTreasure /= blobfishMaskTreasureChanceMultiplyer;
            isEffectActive = false;
        }
    }
}
