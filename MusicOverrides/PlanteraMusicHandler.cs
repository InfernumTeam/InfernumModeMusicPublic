using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InfernumModeMusic.MusicOverrides
{
    public class PlanteraMusicHandler : ModSceneEffect
    {
        public override int Music => MusicLoader.GetMusicSlot(Mod, "Sounds/Music/Plantera");

        public override bool IsSceneEffectActive(Player player) => InfernumModeMusic.CanPlayMusic(NPCID.Plantera);

        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;
    }
}
