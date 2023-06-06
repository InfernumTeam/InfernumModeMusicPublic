using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InfernumModeMusic.MusicOverrides
{
    public class MinibossMusicHandler : ModSceneEffect
    {
        public override int Music => MusicLoader.GetMusicSlot(Mod, "Sounds/Music/Minibosses");

        public override bool IsSceneEffectActive(Player player)
        {
            if (!InfernumModeMusic.InfernumActive)
                return false;

            if (InfernumModeMusic.CanPlayMusic(NPCID.BigMimicCorruption))
                return true;
            if (InfernumModeMusic.CanPlayMusic(NPCID.BigMimicCrimson))
                return true;
            if (InfernumModeMusic.CanPlayMusic(NPCID.BigMimicHallow))
                return true;
            if (InfernumModeMusic.CanPlayMusic(NPCID.SandElemental))
                return true;
            if (InfernumModeMusic.Calamity != null && InfernumModeMusic.CanPlayMusic(InfernumModeMusic.Calamity.Find<ModNPC>("GiantClam").Type))
                return true;

            return false;
        }

        public override SceneEffectPriority Priority => (SceneEffectPriority)10;
    }
}
