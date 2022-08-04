using System.Collections.Generic;
using System.Reflection;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InfernumModeMusic
{
    public class InfernumModeMusic : Mod
    {
        internal static Mod Infernum;

        internal static Mod Calamity;

        internal static IDictionary<int, int> SoundLoaderMusicToItem => (Dictionary<int, int>)typeof(MusicLoader).GetField("musicToItem", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null);
        internal static IDictionary<int, int> SoundLoaderItemToMusic => (Dictionary<int, int>)typeof(MusicLoader).GetField("itemToMusic", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null);
        internal static Dictionary<int, Dictionary<int, int>> SoundLoaderTileToMusic => (Dictionary<int, Dictionary<int, int>>)typeof(MusicLoader).GetField("tileToMusic", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null);

        public static bool InfernumActive
        {
            get
            {
                if (Infernum != null)
                    return (bool)Infernum.Call("GetInfernumActive");
                return false;
            }
        }

        public static bool BossRushActive
        {
            get
            {
                if (Calamity != null)
                    return (bool)Calamity.Call("GetDifficultyActive", "bossrush");
                return false;
            }
        }

        public static bool CanPlayMusic(int npcID)
        {
            bool result = !BossRushActive;
            if (Infernum != null)
                result &= (bool)Infernum.Call("CanPlayMusicForNPC", npcID) && InfernumActive;
            else
                result &= NPC.AnyNPCs(npcID);
            return result;
        }

        public static void OverrideMusicBox(int itemType, int musicSlot, int tileType, int tileFrameY)
        {
            SoundLoaderMusicToItem[musicSlot] = itemType;
            SoundLoaderItemToMusic[itemType] = musicSlot;
            if (!SoundLoaderTileToMusic.ContainsKey(tileType))
                SoundLoaderTileToMusic[tileType] = new Dictionary<int, int>();

            SoundLoaderTileToMusic[tileType][tileFrameY] = musicSlot;
        }

        public override void Load()
        {
            Infernum = null;
            ModLoader.TryGetMod("InfernumMode", out Infernum);

            Calamity = null;
            ModLoader.TryGetMod("CalamityMod", out Calamity);

            OverrideMusicBox(ItemID.MusicBoxBoss3, MusicLoader.GetMusicSlot(this, "Sounds/Music/Boss3"), TileID.MusicBoxes, 36 * 12);
            OverrideMusicBox(ItemID.MusicBoxLunarBoss, MusicLoader.GetMusicSlot(this, "Sounds/Music/MoonLord"), TileID.MusicBoxes, 36 * 32);
        }
    }
}