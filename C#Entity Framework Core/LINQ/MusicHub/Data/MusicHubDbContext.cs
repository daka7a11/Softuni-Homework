namespace MusicHub.Data
{
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Data.Models;

    public class MusicHubDbContext : DbContext
    {
        public MusicHubDbContext()
        {
        }
        public MusicHubDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Performer> Performers { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }
        public virtual DbSet<Song> Songs { get; set; }
        public virtual DbSet<SongPerformer> SongsPerformers { get; set; }
        public virtual DbSet<Writer> Writers { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Song>(entity =>
            {
                entity.HasOne(s => s.Album)
                      .WithMany(a => a.Songs)
                      .HasForeignKey(s => s.AlbumId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(s => s.Writer)
                      .WithMany(w => w.Songs)
                      .HasForeignKey(s => s.WriterId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Album>(entity =>
            {
                entity.HasOne(a => a.Producer)
                      .WithMany(p => p.Albums)
                      .HasForeignKey(a => a.ProducerId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<SongPerformer>(entity =>
            {
                entity.HasKey(x => new { x.SongId, x.PerformerId });

                entity.HasOne(sp => sp.Song)
                      .WithMany(s => s.SongPerformers)
                      .HasForeignKey(sp => sp.SongId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(sp => sp.Performer)
                      .WithMany(p => p.PerformerSongs)
                      .HasForeignKey(sp => sp.PerformerId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

        }
    }
}
