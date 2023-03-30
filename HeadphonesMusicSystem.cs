using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InfernumModeMusic
{
    public class HeadphonesMusicSystem : ModSceneEffect
    {
        public override int Music
        {
            get
            {
                string trackName = Main.LocalPlayer.GetModPlayer<CustomMusicPlayer>().CurrentTrackName;
                return MusicLoader.GetMusicSlot(Mod, $"Sounds/Music/{trackName}");
            }
        }

        public static bool BossIsPresent
        {
            get
            {
                for (int i = 0; i < Main.maxNPCs; i++)
                {
                    if (Main.npc[i] != null)
                    {
                        NPC npc = Main.npc[i];
                        if (IsABoss(npc))
                            return true;
                    }
                }
                return false;
            }
        }

        public override bool IsSceneEffectActive(Player player)
        {
            string trackName = player.GetModPlayer<CustomMusicPlayer>().CurrentTrackName;
            if (trackName == "StormBeforeDawn" && !BossIsPresent)
                return false;

            return player.GetModPlayer<CustomMusicPlayer>().UsingHeadphones && !string.IsNullOrEmpty(trackName);
        }

        public override SceneEffectPriority Priority => (SceneEffectPriority)20;

        public static bool IsABoss(NPC npc)
        {
            if (npc is null || !npc.active)
                return false;
            if (npc.boss && npc.type != NPCID.MartianSaucerCore)
                return true;
            if (npc.type == NPCID.EaterofWorldsBody || npc.type == NPCID.EaterofWorldsHead || npc.type == NPCID.EaterofWorldsTail)
                return true;
            return false;
        }
    }
}
