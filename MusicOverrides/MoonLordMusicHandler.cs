using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InfernumModeMusic.MusicOverrides
{
    public class MoonLordMusicHandler : ModSceneEffect
    {
        public override int Music => MusicLoader.GetMusicSlot(Mod, "Sounds/Music/MoonLord");

        public override bool IsSceneEffectActive(Player player) => InfernumModeMusic.CanPlayMusic(NPCID.MoonLordCore);

        public override void SpecialVisuals(Player player, bool isActive)
        {
            if (!isActive)
                return;

            Main.musicFade[Main.curMusic] = 1f;
        }

        public override SceneEffectPriority Priority => (SceneEffectPriority)10;
    }
}
