using System.Collections.Generic;
using System.Linq;
using StardewValley;
using StardewValley.Locations;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class WearableDwarfHelm
    {
        public const string Name = "Wearable Dwarf Helm";
        public const string Description = "You can Understand Dwarves.\nWhen entering a new level of a mine gain Mad Dwarf King buff:\n+4 Mining\n+2 Speed\n+1 Attack.";
        private static string locaction;
        public static void Activate()
        {
            Game1.player.canUnderstandDwarves = true;
            HatService.OnUpdateTicked = (e) =>
            {
                if (Game1.player.hasMenuOpen.Value || !Game1.player.canMove || !Game1.game1.IsActive || Game1.eventUp)
                {
                    return;
                }

                if (!Game1.currentLocation.name.Value.Contains("UndergroundMine"))
                {
                    return;
                }

                if (!string.IsNullOrEmpty(locaction) && Game1.currentLocation.name.Value == locaction)
                {
                    return;
                }

                locaction = Game1.currentLocation.name.Value;

                Buff dwarfBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
                if (dwarfBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.MiningLevel.Set(4);
                    effects.Speed.Set(2);
                    effects.Attack.Set(1);
                    dwarfBuff = new Buff(
                        id: HatService.BuffId,
                        source: "Deluxe Hats",
                        displaySource: Name,
                        displayName: "Mad Dwarf King",
                        effects: effects
                        );
                    dwarfBuff.description = "Mad Dwarf King\n+4 Mining\n+2 Speed\n+1 Attack";
                    Game1.player.applyBuff(dwarfBuff);
                }
                dwarfBuff.millisecondsDuration = 21510;
            };
        }

        public static void Disable()
        {
            var mus = (LibraryMuseum)Game1.getLocationFromName("ArchaeologyHouse");
            if (mus != null)
            {
                var museumItems = new HashSet<int>(mus.museumPieces.Values.Select(s => int.TryParse(s, out var id) ? id : -1));
                if (museumItems.Contains(96) && museumItems.Contains(97) && museumItems.Contains(98) && museumItems.Contains(99))
                {
                    Game1.player.canUnderstandDwarves = true;
                }
                else
                {
                    Game1.player.canUnderstandDwarves = false;
                }
            }
            Buff dwarfBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
            if (dwarfBuff != null)
            {
                dwarfBuff.millisecondsDuration = 0;
            }
        }
    }
}
