using Terraria;
using Terraria.ModLoader;

namespace InfernumModeMusic.MusicOverrides
{
    public class ExoMechMusicHandler : ModSceneEffect
    {
        public override int Music
        {
            get
            {
                if (InfernumModeMusic.Infernum != null && DraedonThemeTimer > 0)
                {
                    DraedonThemeTimer++;
                    if (DraedonThemeTimer >= 5122f)
                        DraedonThemeTimer = 0f;
                    else
                        return MusicLoader.GetMusicSlot(Mod, "Sounds/Music/Draedon");
                }

                if (!SkyActive)
                    return MusicLoader.GetMusicSlot(InfernumModeMusic.Calamity, "Sounds/Music/DraedonAmbience");

                return MusicLoader.GetMusicSlot(Mod, "Sounds/Music/ExoMechBosses");
            }
        }

        public static float DraedonThemeTimer
        {
            get => (float)InfernumModeMusic.Infernum.Code.GetType("InfernumMode.InfernumMode").GetProperty("DraedonThemeTimer").GetValue(null);
            set => InfernumModeMusic.Infernum.Code.GetType("InfernumMode.InfernumMode").GetProperty("DraedonThemeTimer").SetValue(null, value);
        }

        public static bool SkyActive => (bool)InfernumModeMusic.Calamity.Code.GetType("CalamityMod.Skies.ExoMechsSky").GetProperty("CanSkyBeActive").GetValue(null);

        public override bool IsSceneEffectActive(Player player) => InfernumModeMusic.Calamity != null && InfernumModeMusic.InfernumActive && (InfernumModeMusic.CanPlayMusic(InfernumModeMusic.Calamity.Find<ModNPC>("Draedon").Type) || SkyActive) && 
            !(bool)InfernumModeMusic.Calamity.Code.GetType("CalamityMod.Events.BossRushEvent").GetField("BossRushActive").GetValue(null);

        public override SceneEffectPriority Priority => (SceneEffectPriority)10;
    }
}
