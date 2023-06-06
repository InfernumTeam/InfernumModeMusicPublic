using Terraria;
using Terraria.ModLoader;

namespace InfernumModeMusic.MusicOverrides
{
    public class CalamitasMusicHandler : ModSceneEffect
    {
        public override int Music => MusicLoader.GetMusicSlot(Mod, "Sounds/Music/Calamitas");

        public override bool IsSceneEffectActive(Player player) => InfernumModeMusic.Calamity != null && InfernumModeMusic.CanPlayMusic(InfernumModeMusic.Calamity.Find<ModNPC>("SupremeCalamitas").Type);

        public override SceneEffectPriority Priority => (SceneEffectPriority)10;
    }
}
