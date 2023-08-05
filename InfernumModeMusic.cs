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


        public override void Load()
        {
            Infernum = null;
            ModLoader.TryGetMod("InfernumMode", out Infernum);
            Calamity = null;
            ModLoader.TryGetMod("CalamityMod", out Calamity);

        }
    }
}