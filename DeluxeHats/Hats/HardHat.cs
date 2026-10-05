using StardewValley;
using StardewValley.Buffs;
using System;
using System.Linq;
using Microsoft.Xna.Framework;

namespace DeluxeHats.Hats
{
    public static class HardHat
    {
        public const string Name = "Hard Hat";
        private const float lightRadius = 5f;

        private static string LightId(Farmer player) => $"DeluxeHats.HardHat.{player.UniqueMultiplayerID}";

        private static Vector2 LightPosition(Farmer player) => new Vector2(player.Position.X + 21f, player.Position.Y + 64f);
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff hardHatBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
                if (hardHatBuff == null)
                {
                    var effects = new BuffEffects();
                    effects.Defense.Set(3);
                    effects.Immunity.Set(1);
                    hardHatBuff = new Buff(
                        id: HatService.BuffId,
                        source: HatService.GetTranslation("mod.name"),
                        displaySource: HatService.GetTranslation("hat.hard-hat.name"),
                        displayName: HatService.GetTranslation("hat.hard-hat.buff.name"),
                        effects: effects
                        );
                    hardHatBuff.description = HatService.GetTranslation("hat.hard-hat.buff.description");
                    hardHatBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    HatService.CurrentPlayer.applyBuff(hardHatBuff);
                }

                // Light sources are local to each client and cleared on warp, so keep re-adding the
                // headlamp for any wearer in the location this client is currently viewing.
                string lightId = LightId(HatService.CurrentPlayer);
                if (HatService.CurrentPlayer.currentLocation == null || HatService.CurrentPlayer.currentLocation != Game1.currentLocation)
                {
                    Game1.currentLightSources.Remove(lightId);
                    return;
                }
                if (Game1.currentLightSources.ContainsKey(lightId))
                {
                    Game1.currentLightSources[lightId].position.Value = LightPosition(HatService.CurrentPlayer);
                }
                else
                {
                    Game1.currentLightSources[lightId] = new LightSource(
                        lightId,
                        LightSource.lantern,
                        LightPosition(HatService.CurrentPlayer),
                        lightRadius,
                        new Color(0, 50, 170),
                        LightSource.LightContext.None,
                        HatService.CurrentPlayer.UniqueMultiplayerID);
                }
            };
        }

        public static void Disable()
        {
            if (HatService.CurrentPlayer == null) return;

            Game1.currentLightSources.Remove(LightId(HatService.CurrentPlayer));
            Buff hardHatBuff = HatService.CurrentPlayer.buffs.AppliedBuffs.Values.FirstOrDefault(x => x.id == HatService.BuffId);
            if (hardHatBuff != null)
            {
                hardHatBuff.millisecondsDuration = 0;
            }
        }
    }
}
