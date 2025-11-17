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
                            fields[1] = $"{fields[1]}\n\nDeluxe Hats:\n{description}";
                            data[entry.Key] = string.Join("/", fields);
                        }
                    }
                });
            }
        }

        private string GetHatDescription(string hatName)
        {
            switch (hatName)
            {
                case "???": return UnknownHat.Description;
                case "Abigail's Bow": return AbigailsBow.Description;
                case "Arcane Hat": return ArcaneHat.Description;
                case "Archer's Cap": return ArchersCap.Description;
                case "Beanie": return Beanie.Description;
                case "Blobfish Mask": return BlobfishMask.Description;
                case "Blue Bonnet": return BlueBonnet.Description;
                case "Blue Bow": return BlueBow.Description;
                case "Blue Cowboy Hat": return BlueCowboyHat.Description;
                case "Blue Ribbon": return BlueRibbon.Description;
                case "Bluebird Mask": return BluebirdMask.Description;
                case "Bowler Hat": return BowlerHat.Description;
                case "Bridal Veil": return BridalVeil.Description;
                case "Bucket Hat": return BucketHat.Description;
                case "Butterfly Bow": return ButterflyBow.Description;
                case "Cat Ears": return CatEars.Description;
                case "Chef Hat": return ChefHat.Description;
                case "Chicken Mask": return ChickenMask.Description;
                case "Cone Hat": return ConeHat.Description;
                case "Cool Cap": return CoolCap.Description;
                case "Copper Pan": return CopperPan.Description;
                case "Cowboy Hat": return CowboyHat.Description;
                case "Cowgal Hat": return CowgalHat.Description;
                case "Cowpoke Hat": return CowpokeHat.Description;
                case "Dark Ballcap": return DarkBallcap.Description;
                case "Dark Cowboy Hat": return DarkCowboyHat.Description;
                case "Dark Velvet Bow": return DarkVelvetBow.Description;
                case "Daisy": return Daisy.Description;
                case "Delicate Bow": return DelicateBow.Description;
                case "Deluxe Cowboy Hat": return DeluxeCowboyHat.Description;
                case "Deluxe Pirate Hat": return DeluxePirateHat.Description;
                case "Dinosaur Hat": return DinosaurHat.Description;
                case "Earmuffs": return Earmuffs.Description;
                case "Elegant Turban": return ElegantTurban.Description;
                case "Emily's Magic Hat": return EmilysMagicHat.Description;
                case "Eye Patch": return EyePatch.Description;
                case "Fashion Hat": return FashionHat.Description;
                case "Fedora": return Fedora.Description;
                case "Fishing Hat": return FishingHat.Description;
                case "Flat Topped Hat": return FlatToppedHat.Description;
                case "Floppy Beanie": return FloppyBeanie.Description;
                case "Forager's Hat": return ForagersHat.Description;
                case "Frog Hat": return FrogHat.Description;
                case "Garbage Hat": return GarbageHat.Description;
                case "Gil's Hat": return GilsHat.Description;
                case "Gnome's Cap": return GnomesCap.Description;
                case "Goblin Mask": return GoblinMask.Description;
                case "Goggles": return Goggles.Description;
                case "Gold Pan": return GoldPan.Description;
                case "Golden Helmet": return GoldenHelmet.Description;
                case "Golden Mask": return GoldenMask.Description;
                case "Good Ol' Cap": return GoodOlCap.Description;
                case "Governor's Hat": return GovernorsHat.Description;
                case "Green Turban": return GreenTurban.Description;
                case "Hair Bone": return HairBone.Description;
                case "Hard Hat": return HardHat.Description;
                case "Hunter's Cap": return HuntersCap.Description;
                case "Infinity Crown": return InfinityCrown.Description;
                case "Iridium Pan": return IridiumPan.Description;
                case "Jester Hat": return JesterHat.Description;
                case "Joja Cap": return JojaCap.Description;
                case "Junimo Hat": return JunimoHat.Description;
                case "Knight's Helmet": return KnightsHelmet.Description;
                case "Laurel Wreath Crown": return LaurelWreathCrown.Description;
                case "Leprechaun Hat": return LeprechaunHat.Description;
                case "Living Hat": return LivingHat.Description;
                case "Logo Cap": return LogoCap.Description;
                case "Lucky Bow": return LuckyBow.Description;
                case "Magic Cowboy Hat": return MagicCowboyHat.Description;
                case "Magic Turban": return MagicTurban.Description;
                case "Mouse Ears": return MouseEars.Description;
                case "Mr. Qi's Hat": return MrQisHat.Description;
                case "Mummy Mask": return MummyMask.Description;
                case "Mushroom Cap": return MushroomCap.Description;
                case "Mystery Hat": return MysteryHat.Description;
                case "Official Cap": return OfficialCap.Description;
                case "Pageboy Cap": return PageboyCap.Description;
                case "Panda Hat": return PandaHat.Description;
                case "Paper Hat": return PaperHat.Description;
                case "Party Hat": return PartyHat.Description;
                case "Pink Bow": return PinkBow.Description;
                case "Pirate Hat": return PirateHat.Description;
                case "Plum Chapeau": return PlumChapeau.Description;
                case "Polka Bow": return PolkaBow.Description;
                case "Propeller Hat": return PropellerHat.Description;
                case "Pumpkin Mask": return PumpkinMask.Description;
                case "Qi Mask": return QiMask.Description;
                case "Raccoon Hat": return RaccoonHat.Description;
                case "Radioactive Goggles": return RadioactiveGoggles.Description;
                case "Red Cowboy Hat": return RedCowboyHat.Description;
                case "Red Fez": return RedFez.Description;
                case "Sailor's Cap": return SailorsCap.Description;
                case "Santa Hat": return SantaHat.Description;
                case "Skeleton Mask": return SkeletonMask.Description;
                case "Small Cap": return SmallCap.Description;
                case "Sombrero": return Sombrero.Description;
                case "Sou'wester": return Souwester.Description;
                case "Space Helmet": return SpaceHelmet.Description;
                case "Sports Cap": return SportsCap.Description;
                case "Spotted Headscarf": return SpottedHeadscarf.Description;
                case "Squid Hat": return SquidHat.Description;
                case "Squire's Helmet": return SquiresHelmet.Description;
                case "Star Helmet": return StarHelmet.Description;
                case "Steel Pan": return SteelPan.Description;
                case "Straw Hat": return StrawHat.Description;
                case "Sunglasses": return Sunglasses.Description;
                case "Swashbuckler Hat": return SwashbucklerHat.Description;
                case "Tiara": return Tiara.Description;
                case "Tiger Hat": return TigerHat.Description;
                case "Top Hat": return TopHat.Description;
                case "Totem Mask": return TotemMask.Description;
                case "Tricorn Hat": return TricornHat.Description;
                case "Tropiclip": return Tropiclip.Description;
                case "Trucker Hat": return TruckerHat.Description;
                case "Warrior Helmet": return WarriorHelmet.Description;
                case "Watermelon Band": return WatermelonBand.Description;
                case "Wearable Dwarf Helm": return WearableDwarfHelm.Description;
                case "White Bow": return WhiteBow.Description;
                case "White Turban": return WhiteTurban.Description;
                case "Witch Hat": return WitchHat.Description;
                default: return null;
            }
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
