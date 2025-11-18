using System.Linq;
using StardewModdingAPI;
using StardewValley;

namespace DeluxeHats.Hats
{
    public static class TotemMask
    {
        public const string Name = "Totem Mask";
        public const string Description = "Chance not to consume totem on use.";

        private const float saveTotemChance = 0.40f;
        public static void Activate()
        {
            HatService.OnButtonPressed = (e) =>
            {
                if (e.IsDown(SButton.MouseRight) || e.IsDown(SButton.ControllerX))
                {
                    if (Game1.activeClickableMenu != null
                    || !Game1.displayFarmer
                    || Game1.dialogueUp
                    || !HatService.CurrentPlayer.canMove
                    || HatService.CurrentPlayer.isRidingHorse()
                    || Game1.isFestival()
                    || Game1.isWarping
                    || Game1.eventUp
                    || Game1.fadeIn
                    || HatService.CurrentPlayer.isInBed.Value
                    || Game1.isActionAtCurrentCursorTile
                    || Game1.fadeToBlack)
                    {
                        return;
                    }
                    if (HatService.CurrentPlayer.CurrentItem != null
                        && HatService.CurrentPlayer.ActiveObject != null
                        && new string[] { "Warp Totem: Farm", "Warp Totem: Beach", "Warp Totem: Desert", "Rain Totem" }.Contains(HatService.CurrentPlayer.CurrentItem.Name))
                    {
                        HatService.Helper.Input.Suppress(SButton.MouseRight);
                        if (HatService.CurrentPlayer.ActiveObject.performUseAction(HatService.CurrentPlayer.currentLocation))
                        {
                            if (!(Game1.random.NextDouble() < saveTotemChance))
                            {
                                HatService.CurrentPlayer.reduceActiveItemByOne();
                            }
                        }
                    }
                }
            };
        }

        public static void Disable()
        {
            HatService.OnButtonPressed = null;
        }
    }
}
