using StardewValley;
using StardewValley.Buffs;
using System;
using System.Linq;

namespace DeluxeHats.Hats
{
    public static class PartyHat
    {
        public const string Name = "Party Hat";
        public const string Description = "Gain Party Time Buff:\n+3 Luck";

        public static void Activate()
        {
            var effects = new BuffEffects();
            effects.LuckLevel.Set(3);

            var buff = new Buff(
                id: HatService.BuffId,
                source: "Deluxe Hats",
                displaySource: Name,
                displayName: "Party Time",
                effects: effects
            );
            buff.description = "Party Time\n+3 Luck";
            buff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
            HatService.CurrentPlayer.applyBuff(buff);

            HatService.OnTimeChanged = (e) =>
            {
                Buff partyBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
                if (partyBuff != null)
                {
                    partyBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                }
            };
        }

        public static void Disable()
        {
            Buff partyBuff = Game1.buffsDisplay.GetSortedBuffs().FirstOrDefault(x => x.id == HatService.BuffId);
            if (partyBuff != null)
            {
                partyBuff.millisecondsDuration = 0;
            }
        }
    }
}
