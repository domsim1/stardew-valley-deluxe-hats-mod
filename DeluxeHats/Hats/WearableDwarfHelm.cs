using System;
using System.Linq;
using StardewValley;
using StardewValley.Buffs;

namespace DeluxeHats.Hats
{
    public static class WearableDwarfHelm
    {
        public const string Name = "Wearable Dwarf Helm";

        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                if (HatService.CurrentPlayer?.currentLocation?.Name == null)
                    return;

                Buff dwarfBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (!HatService.CurrentPlayer.currentLocation.Name.Contains("Mine"))
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
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.wearable-dwarf-helm.name"),
                        displayName: HatService.GetTranslation("hat.wearable-dwarf-helm.buff.name"),
                        effects: effects
                    );
                    dwarfBuff.description = HatService.GetTranslation("hat.wearable-dwarf-helm.buff.description");
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
