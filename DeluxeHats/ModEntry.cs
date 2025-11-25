using StardewModdingAPI;
using StardewModdingAPI.Events;
using DeluxeHats.Hats;

namespace DeluxeHats
{
    public enum HatNames
    {

    }
    public class ModEntry : Mod
    {
        private void OnAssetRequested(object sender, AssetRequestedEventArgs e)
        {
            if (e.NameWithoutLocale.IsEquivalentTo("Data/Hats"))
            {
                e.Edit(asset =>
                {
                    var data = asset.AsDictionary<string, string>().Data;

                    foreach (var entry in data)
                    {
                        string[] fields = entry.Value.Split('/');
                        if (fields.Length < 2)
                            continue;

                        string hatName = fields[0];
                        string description = GetHatDescription(hatName);

                        if (!string.IsNullOrEmpty(description))
                        {
                            string prefix = Helper.Translation.Get("mod.prefix");
                            fields[1] = $"{fields[1]}\n\n{prefix}\n{description}";
                            data[entry.Key] = string.Join("/", fields);
                        }
                    }
                });
            }
        }

        private string HatNameToTranslationKey(string hatName)
        {
            string slug = hatName.ToLower()
                .Replace("'", "")
                .Replace(" ", "-")
                .Replace(".", "");

            if (hatName == "???")
                slug = "unknown";

            return $"hat.{slug}.description";
        }

        private string GetHatDescription(string hatName)
        {
            string translationKey = HatNameToTranslationKey(hatName);
            string description = Helper.Translation.Get(translationKey);

            if (description == translationKey)
                return null;

            return description;
        }

        public override void Entry(IModHelper helper)
        {
            HatService.Monitor = Monitor;
            HatService.Helper = helper;

            helper.Events.Content.AssetRequested += OnAssetRequested;
            helper.Events.GameLoop.SaveLoaded += SaveLoaded;
            helper.Events.GameLoop.DayStarted += HatService.DayStarted;
            helper.Events.GameLoop.ReturnedToTitle += ReturnedToTitle;
            helper.Events.GameLoop.UpdateTicked += HatService.UpdateTicked;
            helper.Events.GameLoop.OneSecondUpdateTicked += OnOneSecondUpdateTicked;
            helper.Events.GameLoop.TimeChanged += HatService.TimeChanged;
            helper.Events.Player.InventoryChanged += HatService.InventoryChanged;
            helper.Events.Input.ButtonPressed += HatService.ButtonPressed;
            helper.Events.GameLoop.DayEnding += HatService.DayEnding;
        }

        private void SaveLoaded(object sender, SaveLoadedEventArgs e)
        {
            HatService.SetupPlayerHatTracking();
        }

        private void OnOneSecondUpdateTicked(object sender, OneSecondUpdateTickedEventArgs e)
        {
            HatService.SetupPlayerHatTracking();
        }

        private void ReturnedToTitle(object sender, ReturnedToTitleEventArgs e)
        {
            HatService.CleanUp();
        }
    }
}
