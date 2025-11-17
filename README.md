# Deluxe Hats

Deluxe Hats is a mod for Stardew Valley that brings unique mechanics to hats. The goal behind this mod is to give the player a better sense of achievement when they spend possibly hours to obtain a particular hat.  Without this mod, hats only serve a purpose as a cosmetic item. With this mod, hats will have unique effects that alter gameplay, making them a valuable asset to any player.

## Multiplayer Support

The mod is fully compatible with multiplayer (both online and splitscreen). **All players must have the mod installed** for it to work correctly. Each player's hat effects are tracked independently, so multiple players can wear different hats with different effects simultaneously.

## Hat Effects

For a complete list of all available hats and their effects, please see **[Hats and Effects](HATS_AND_EFFECTS.md)** 

## How to Contribute

All contributions would be much appreciated. You can contribute by:

- Implement a hat or fix a bug.
- Report an [issue](https://github.com/domsim1/stardew-valley-deluxe-hats-mod/issues).
- Buy me a [coffee](https://www.buymeacoffee.com/domsim1) ☕.

## How to Implement a Hat or fix a bug

Create a fork of the repository, then create a branch based on `v2` (for Stardew Valley 1.6) called `feature/<hat-name>` if its a hat effect or `bugfix/<issue-number>` if its a bug fix. If the branch you are developing on is behind the base branch, please rebase, do **not** merge into your branch.

The project can be opened with Visual Studio and is built using [SMAPI](https://stardewvalleywiki.com/Modding:Modder_Guide/APIs) 4.x for Stardew Valley 1.6. All 120 hats in Stardew Valley have corresponding files in the `DeluxeHats/Hats/` directory.

To implement a hat effect, find the file with the same name as the hat in the `Hats` directory. The file structure looks like this:

```C#
using StardewValley;
using StardewValley.Buffs;
using System;
using System.Linq;

namespace DeluxeHats.Hats
{
  public static class BowlerHat
  {
    public const string Name = "Bowler Hat";
    public const string Description = "Gain the Dapper Buff:\n+1 Defense";

    public static void Activate()
    {
      // Implement hat effect here
    }

    public static void Disable()
    {
      // Clean up hat effect here
    }
  }
}
```

The `Activate()` method is called when the player puts on the hat. The `Disable()` method is called when the player takes off the hat. Logic to apply effects should go within the `Activate()` method and clean up should be done within the `Disable()` method. If no clean up is needed, leave the `Disable()` method empty.

**Important**: Hat classes are **automatically discovered** via reflection by matching the `Name` constant to the equipped hat. You do **not** need to register new hats in `HatService.cs` - just create the hat file with the proper `Name` constant and the mod will find it automatically.

To access SMAPI `Mod.Helper` use `HatService.Helper` and `Mod.Monitor` use `HatService.Monitor`.

Do **not** use events from SMAPI directly from `HatService.Helper`. Instead, bind a lambda function to the corresponding delegate variable. For example, if you wish to use `Helper.Events.GameLoop.UpdateTicked`, assign a lambda function to `HatService.OnUpdateTicked` like so:

```C#
public static void Activate()
{
  HatService.OnUpdateTicked = (e) =>
  {
    // Do stuff
  };
}
```

The `HatService.OnUpdateTicked` delegate will be set to `null` automatically when the hat is taken off. This does **not** need to be done within the `Disable()` method.

If the event you wish to use does not yet have a delegate, you can add it to the `HatService` class like so:

```C#
public delegate void OnNewEventDelegate(NewEventArgs e);
public static OnNewEventDelegate OnNewEvent;
```

Then set it to `null` in the `CleanUp()` method:

```C#
public static void CleanUp()
{
  DisableHat?.Invoke();
  DisableHat = null;
  OnUpdateTicked = null;
  OnNewEvent = null;
}
```

Create a method that will be called by the SMAPI event:

```C#
public static void NewEvent(object sender, NewEventArgs e)
{
  OnNewEvent?.Invoke(e);
}
```

Finally, bind the event in the `ModEntry.Entry()` method:

```C#
helper.Events.SomeCategory.NewEvent += HatService.NewEvent;
```

## Help

If you know the basics of C# and would like help implementing a hat feature, open an issue with the `help wanted` tag explaining what you are trying to accomplish and I (or maybe someone in the community) will be happy to help.
