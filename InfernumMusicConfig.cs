using System.ComponentModel;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace InfernumModeMusic
{
    [BackgroundColor(96, 30, 53, 216)]
    public class InfernumMusicConfig : ModConfig
    {
        public static InfernumMusicConfig Instance => ModContent.GetInstance<InfernumMusicConfig>();

        public override ConfigScope Mode => ConfigScope.ClientSide;

        [BackgroundColor(224, 127, 180, 192)]
        [DefaultValue(true)]
        public bool OverrideCalTheme
        {
            get; set;
        }

        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref NetworkText message) => false;
    }
}
