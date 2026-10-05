using StardewValley;
using System;
using System.Linq;
using StardewValley.Buffs;
using StardewValley.TerrainFeatures;
using Microsoft.Xna.Framework;

namespace DeluxeHats.Hats
{
    public static class LivingHat
    {
        public const string Name = "Living Hat";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff livingBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (livingBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.FarmingLevel.Set(3);
                    livingBuff = new Buff(
                        id: HatService.BuffId,
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.living-hat.name"),
                        displayName: HatService.GetTranslation("hat.living-hat.buff.name"),
                        effects: effects
                        );
                    livingBuff.description = HatService.GetTranslation("hat.living-hat.buff.description");
                    livingBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(livingBuff);
                }

                var location = HatService.CurrentPlayer.currentLocation;
                if (location == null || !e.IsMultipleOf(30))
                    return;
                Vector2 playerTile = HatService.CurrentPlayer.Tile;
                for (int x = -1; x <= 1; x++)
                {
                    for (int y = -1; y <= 1; y++)
                    {
                        var tile = new Vector2(playerTile.X + x, playerTile.Y + y);
                        if (location.terrainFeatures.TryGetValue(tile, out var feature)
                            && feature is HoeDirt dirt
                            && dirt.state.Value != HoeDirt.watered)
                        {
                            dirt.state.Value = HoeDirt.watered;
                        }
                    }
                }
            };
        }

        public static void Disable()
        {
            Buff livingBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (livingBuff != null)
            {
                livingBuff.millisecondsDuration = 0;
            }
        }
    }
}
