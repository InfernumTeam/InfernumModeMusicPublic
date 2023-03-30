using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace InfernumModeMusic
{
    public class CustomMusicPlayer : ModPlayer
    {
        public bool UsingHeadphones
        {
            get;
            set;
        }

        public string CurrentTrackName
        {
            get;
            set;
        }

        public bool UnlockAllMusic
        {
            get;
            set;
        }

        public float HeadRotationTime
        {
            get;
            set;
        }

        public bool ListeningToMusic
        {
            get
            {
                if (CurrentTrackName == "StormBeforeDawn" && !HeadphonesMusicSystem.BossIsPresent)
                    return false;

                return UsingHeadphones && !string.IsNullOrEmpty(CurrentTrackName);
            }
        }

        public override void PreUpdate()
        {
            if (!UsingHeadphones)
                CurrentTrackName = string.Empty;

            // Create music particles if a track is playing.
            if (Main.myPlayer == Player.whoAmI && Main.rand.NextBool(16) && ListeningToMusic)
            {
                int musicNoteID = Main.rand.Next(ProjectileID.EighthNote, ProjectileID.TiedEighthNote + 1);
                Vector2 noteSpawnPosition = Player.Top + new Vector2(Main.rand.NextFloatDirection() * 16f, Main.rand.NextFloat(12f));

                int note = Projectile.NewProjectile(Player.GetSource_FromThis(), noteSpawnPosition, -Vector2.UnitY.RotatedByRandom(0.7f), musicNoteID, 0, 0f, Player.whoAmI);
                if (Main.projectile.IndexInRange(note))
                    Main.projectile[note].scale = 0.5f;
            }
        }

        public override void ModifyDrawInfo(ref PlayerDrawSet drawInfo)
        {
            if (ListeningToMusic && InfernumModeMusic.Infernum is not null)
                HeadRotationTime = (float)InfernumModeMusic.Infernum?.Call("BopHeadToMusic", Player, HeadRotationTime);
        }

        public override void SaveData(TagCompound tag)
        {
            tag["UsingHeadphones"] = UsingHeadphones;
            tag["UnlockAllMusic"] = UnlockAllMusic;
            tag["CurrentTrackName"] = CurrentTrackName;
        }

        public override void LoadData(TagCompound tag)
        {
            UsingHeadphones = tag.GetBool("UsingHeadphones");
            UnlockAllMusic = tag.GetBool("UnlockAllMusic");
            CurrentTrackName = tag.GetString("CurrentTrackName");
        }
    }
}
