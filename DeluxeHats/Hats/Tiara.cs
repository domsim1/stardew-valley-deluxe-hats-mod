using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Linq;
using HarmonyLib;
using StardewValley;
using StardewValley.Events;

namespace DeluxeHats.Hats
{
    public static class Tiara
    {
        public const string Name = "Tiara";
        public const string Description = "When sleeping increase the chance for the fairy farm event.";
        public static void Activate()
        {
            HatService.Harmony.Patch(
                original: AccessTools.Method(typeof(Utility), nameof(Utility.pickFarmEvent)),
                postfix: new HarmonyMethod(typeof(Tiara), nameof(Tiara.PickFarmEvent_Postfix)));
        }

        public static void Disable()
        {
            HatService.Harmony.Unpatch(
                AccessTools.Method(typeof(Utility), nameof(Utility.pickFarmEvent)),
                HarmonyPatchType.Postfix,
                HatService.HarmonyId);
        }

        public static void PickFarmEvent_Postfix(ref FarmEvent __result)
        {
            try
            {
                if (__result == null)
                {
                    if (Game1.random.NextDouble() < 0.45)
                    { 
                        __result = new FairyEvent();
                    }
                }
            }
            catch (Exception ex)
            {
                HatService.Monitor.Log($"Failed in {nameof(PickFarmEvent_Postfix)}:\n{ex}");
            }
        }
    }
}
