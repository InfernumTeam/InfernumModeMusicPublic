using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InfernumModeMusic.MusicOverrides
{
    public class MechBossMusicHandler : ModSceneEffect
    {
        public override int Music => MusicLoader.GetMusicSlot(Mod, "Sounds/Music/MechBosses");

        public override bool IsSceneEffectActive(Player player) =>
            InfernumModeMusic.CanPlayMusic(NPCID.Spazmatism) || InfernumModeMusic.CanPlayMusic(NPCID.Retinazer) ||
            InfernumModeMusic.CanPlayMusic(NPCID.SkeletronPrime) || InfernumModeMusic.CanPlayMusic(NPCID.TheDestroyer);

        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;
    }
}
