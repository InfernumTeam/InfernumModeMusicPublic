using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InfernumModeMusic.MusicOverrides
{
    public class EaterOfWorldsMusicHandler : ModSceneEffect
    {
        public override int Music => MusicLoader.GetMusicSlot(Mod, "Sounds/Music/EaterOfWorlds");

        public override bool IsSceneEffectActive(Player player) => InfernumModeMusic.CanPlayMusic(NPCID.EaterofWorldsHead);

        public override SceneEffectPriority Priority => (SceneEffectPriority)9;
    }
}
