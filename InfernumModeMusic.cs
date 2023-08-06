using System;
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

        public override object Call(params object[] args)
        {
            if (args is null || args.Length <= 0)
                return new ArgumentException("ERROR: No function name specified. First argument must be a function name.");
            if (args[0] is not string)
                return new ArgumentException("ERROR: First argument must be a string function name.");

            string methodName = args[0].ToString();
            if (methodName == "OverrideCalTheme")
                return InfernumMusicConfig.Instance.OverrideCalTheme;
            return null;
        }
    }
}