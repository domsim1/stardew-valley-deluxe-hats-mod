using System;
using System.Linq;
using StardewValley;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class WearableDwarfHelm
    {
        public const string Name = "Wearable Dwarf Helm";
        public const string Description = "When in the Mines or Skull Cavern gain the Mad Dwarf King buff:\n+4 Mining, +2 Speed, +1 Attack";

        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff dwarfBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (!HatService.CurrentPlayer.currentLocation.name.Value.Contains("Mine"))
                {
                    if (dwarfBuff != null)
                    {
                        dwarfBuff.millisecondsDuration = 0;
                    }
                    return;
                }
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
                    dwarfBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(dwarfBuff);
                }
            };
        }

        public static void Disable()
        {
            Buff dwarfBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (dwarfBuff != null)
            {
                dwarfBuff.millisecondsDuration = 0;
            }
        }
    }
}
