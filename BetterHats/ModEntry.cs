using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace BetterHats
{
    public enum HatNames 
    {
    
    }
    public class ModEntry : Mod
    {
        
        public override void Entry(IModHelper helper)
        {
            HatService.Monitor = Monitor;
            HatService.Helper = helper;
            helper.Events.GameLoop.SaveLoaded += SaveLoaded;
            helper.Events.GameLoop.DayStarted += HatService.DayStarted;
            helper.Events.GameLoop.ReturnedToTitle += ReturnedToTitle;
            helper.Events.GameLoop.UpdateTicked += HatService.UpdateTicked;
            helper.Events.GameLoop.TimeChanged += HatService.TimeChanged;
            helper.Events.Player.InventoryChanged += HatService.InventoryChanged;
            helper.Events.Input.ButtonPressed += HatService.ButtonPressed;
        }


        private void SaveLoaded(object sender, SaveLoadedEventArgs e)
        {
            Game1.player.hat.fieldChangeEvent += HatService.HatChanged;
        }

        private void ReturnedToTitle(object sender, ReturnedToTitleEventArgs e)
        {
            HatService.CleanUp();
        } 
    }
}
