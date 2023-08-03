using Terraria;
using Terraria.ModLoader;

namespace InfernumModeMusic.MusicOverrides
{
    public class AdultEidolonWyrmMusicHandler : ModSceneEffect
    {
        public override int Music => MusicLoader.GetMusicSlot(Mod, "Sounds/Music/AdultEidolonWyrm");

        public override bool IsSceneEffectActive(Player player) => InfernumModeMusic.Calamity != null && InfernumModeMusic.CanPlayMusic(InfernumModeMusic.Calamity.Find<ModNPC>("PrimordialWyrmHead").Type);

        public override SceneEffectPriority Priority => (SceneEffectPriority)10;
    }
}
