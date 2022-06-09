using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolos_02.Models
{
    public class s22527Context : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<MusicianTrack> MusicianTracks { get; set; }
        public DbSet<MusicLabel> MusicLabels { get; set; }
        public DbSet<Track> Tracks { get; set; }

        public s22527Context()
        {

        }

        public s22527Context(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Album>(e =>
            {
                e.HasKey(m => m.IdAlbum);
                e.Property(m => m.IdAlbum).ValueGeneratedOnAdd();
                e.Property(m => m.AlbumName).HasMaxLength(30).IsRequired();
            });

            modelBuilder.Entity<Musician>(e =>
            {
                e.HasKey(m => m.IdMusician);
                e.Property(m => m.IdMusician).ValueGeneratedOnAdd();

                e.Property(m => m.FirstName).HasMaxLength(30).IsRequired();
                e.Property(m => m.LastName).HasMaxLength(50).IsRequired();
                e.Property(m => m.Nickname).HasMaxLength(20);
            });

            modelBuilder.Entity<MusicianTrack>(e =>
            {
                e.HasKey(m => m.IdMusicianTrack);
                e.Property(m => m.IdMusicianTrack).ValueGeneratedOnAdd();
                e.HasOne(m => m.Musician).WithMany(m => m.MusicianTracks).HasForeignKey(m => m.IdMusician);
                e.HasOne(m => m.Track).WithMany(m => m.MusicianTracks).HasForeignKey(m => m.IdTrack);
            });

            modelBuilder.Entity<MusicLabel>(e =>
            {
                e.HasKey(m => m.IdMusicLabel);
                e.Property(m => m.IdMusicLabel).ValueGeneratedOnAdd();
                e.Property(m => m.Name).HasMaxLength(50).IsRequired();
                e.HasMany(m => m.Albums).WithOne(m => m.MusicLabel).HasForeignKey(m => m.IdMusicLabel);
            });

            modelBuilder.Entity<Track>(e =>
            {
                e.HasKey(m => m.IdTrack);
                e.Property(m => m.IdTrack).ValueGeneratedOnAdd();
                e.Property(m => m.TrackName).HasMaxLength(20).IsRequired();
                e.HasOne(m => m.Album).WithMany(m => m.Tracks).HasForeignKey(m => m.IdMusicAlbum);
            });
        }
    }
}
