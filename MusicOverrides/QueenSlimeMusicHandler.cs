using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InfernumModeMusic.MusicOverrides
{
    public class QueenSlimeMusicHandler : ModSceneEffect
    {
        public override int Music => MusicLoader.GetMusicSlot(Mod, "Sounds/Music/QueenSlime");

        public override bool IsSceneEffectActive(Player player) => InfernumModeMusic.CanPlayMusic(NPCID.QueenSlimeBoss);

        public override SceneEffectPriority Priority => (SceneEffectPriority)10;
    }
}
