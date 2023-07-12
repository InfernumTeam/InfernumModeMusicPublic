using System.ComponentModel;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace InfernumModeMusic
{
    [Label("Config")]
    [BackgroundColor(96, 30, 53, 216)]
    public class InfernumMusicConfig : ModConfig
    {
        public static InfernumMusicConfig Instance => ModContent.GetInstance<InfernumMusicConfig>();

        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Label("Override Calamitas' Theme")]
        [BackgroundColor(224, 127, 180, 192)]
        [DefaultValue(true)]
        [Tooltip("Determines whether Calamitas' track is overridden. If disabled, Stained Brutal Calamity will play instead, assuming Calamity's Music Mod is enabled.")]
        public bool OverrideCalTheme
        {
            get; set;
        }

        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message) => false;
    }
}
