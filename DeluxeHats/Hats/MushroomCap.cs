using StardewValley;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using Object = StardewValley.Object;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class MushroomCap
    {
        public const string Name = "Mushroom Cap";
        private const string purpleMushroom = "(O)422";
        private const double purpleMushroomChance = 0.05;

        private static string[] GetSeasonalMushrooms()
        {
            switch (Game1.currentSeason)
            {
                case "spring": return new[] { "(O)404", "(O)257" }; // Common Mushroom, Morel
                case "summer": return new[] { "(O)404", "(O)420" }; // Common Mushroom, Red Mushroom
                case "fall": return new[] { "(O)404", "(O)281", "(O)420" }; // Common Mushroom, Chanterelle, Red Mushroom
                default: return new[] { "(O)404" }; // Common Mushroom
            }
        }

        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff mushroomBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (mushroomBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.ForagingLevel.Set(3);
                    effects.LuckLevel.Set(2);
                    mushroomBuff = new Buff(
                        id: HatService.BuffId,
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.mushroom-cap.name"),
                        displayName: HatService.GetTranslation("hat.mushroom-cap.buff.name"),
                        effects: effects
                        );
                    mushroomBuff.description = HatService.GetTranslation("hat.mushroom-cap.buff.description");
                    mushroomBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(mushroomBuff);
                }
            };

            HatService.OnDayStarted = (e) =>
            {
                // World changes are synced from the host, so only the host spawns the mushroom.
                if (!Context.IsMainPlayer || !Game1.getOnlineFarmers().Contains(HatService.CurrentPlayer))
                    return;
                Farm farm = Game1.getFarm();
                Point door = farm.GetMainFarmHouseEntry();
                for (int attempt = 0; attempt < 30; attempt++)
                {
                    var tile = new Vector2(door.X + Game1.random.Next(-5, 6), door.Y + Game1.random.Next(1, 7));
                    if (farm.objects.ContainsKey(tile) || farm.terrainFeatures.ContainsKey(tile) || !farm.CanItemBePlacedHere(tile))
                        continue;

                    string[] mushrooms = GetSeasonalMushrooms();
                    string itemId = Game1.random.NextDouble() < purpleMushroomChance
                        ? purpleMushroom
                        : mushrooms[Game1.random.Next(mushrooms.Length)];
                    Object mushroom = ItemRegistry.Create<Object>(itemId);
                    mushroom.IsSpawnedObject = true;
                    farm.objects.Add(tile, mushroom);

                    if (HatService.CurrentPlayer.IsLocalPlayer)
                    {
                        Game1.addHUDMessage(new HUDMessage(HatService.GetTranslation("hat.mushroom-cap.sprouted"), HUDMessage.newQuest_type));
                    }
                    return;
                }
            };
        }

        public static void Disable()
        {
            Buff mushroomBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (mushroomBuff != null)
            {
                mushroomBuff.millisecondsDuration = 0;
            }
        }
    }
}
