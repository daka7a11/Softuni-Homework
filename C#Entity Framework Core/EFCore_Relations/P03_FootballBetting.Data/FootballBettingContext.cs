
using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {
        }

        public FootballBettingContext(DbContextOptions<FootballBettingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bet> Bets { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Town> Towns { get; set; }
        public virtual DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-Q72FB2M\SQLEXPRESS;Database=Football Bookmaker System;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(x => x.TeamId);

                entity.Property(x => x.Name)
                      .IsRequired()
                      .IsUnicode()
                      .HasMaxLength(50);

                entity.Property(x => x.LogoUrl)
                      .IsRequired()
                      .IsUnicode(false);

                entity.Property(x => x.Initials)
                      .IsRequired()
                      .IsUnicode(false)
                      .HasMaxLength(5);

                entity.HasOne(t => t.PrimaryKitColor)
                      .WithMany(c => c.PrimaryKitTeams)
                      .HasForeignKey(t => t.PrimaryKitColorId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.SecondaryKitColor)
                      .WithMany(c => c.SecondaryKitTeams)
                      .HasForeignKey(t => t.SecondaryKitColorId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.Town)
                      .WithMany(to => to.Teams)
                      .HasForeignKey(t => t.TownId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.HasKey(x => x.ColorId);

                entity.Property(c => c.Name)
                      .IsRequired()
                      .IsUnicode()
                      .HasMaxLength(50);
            });

            modelBuilder.Entity<Town>(entity =>
            {
                entity.HasKey(x => x.TownId);

                entity.Property(t => t.Name)
                      .IsRequired()
                      .IsUnicode()
                      .HasMaxLength(100);

                entity.HasOne(t => t.Country)
                      .WithMany(c => c.Towns)
                      .HasForeignKey(t => t.CountryId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(x => x.CountryId);

                entity.Property(c => c.Name)
                      .IsRequired()
                      .IsUnicode()
                      .HasMaxLength(50);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasKey(x => x.PlayerId);

                entity.Property(p => p.Name)
                      .IsRequired()
                      .IsUnicode()
                      .HasMaxLength(100);

                entity.HasOne(p => p.Team)
                      .WithMany(t => t.Players)
                      .HasForeignKey(p => p.TeamId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.Position)
                      .WithMany(po => po.Players)
                      .HasForeignKey(p => p.PositionId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasKey(x => x.PositionId);

                entity.Property(p => p.Name)
                      .IsRequired()
                      .IsUnicode()
                      .HasMaxLength(50);
            });

            modelBuilder.Entity<PlayerStatistic>(entity =>
            {
                entity.HasKey(x => new { x.PlayerId, x.GameId });

                entity.HasOne(ps => ps.Player)
                      .WithMany(p => p.PlayerStatistics)
                      .HasForeignKey(ps => ps.PlayerId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ps => ps.Game)
                      .WithMany(g => g.PlayerStatistics)
                      .HasForeignKey(ps => ps.GameId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.Property(ps => ps.ScoredGoals).IsRequired();

                entity.Property(ps => ps.Assists).IsRequired();

                entity.Property(ps => ps.MinutesPlayed).IsRequired();
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(x => x.GameId);

                entity.Property(g => g.HomeTeamGoals).IsRequired();

                entity.Property(g => g.AwayTeamGoals).IsRequired();

                entity.Property(g => g.DateTime).IsRequired();

                entity.Property(g => g.HomeTeamBetRate).IsRequired();

                entity.Property(g => g.AwayTeamBetRate).IsRequired();

                entity.Property(g => g.DrawBetRate).IsRequired();

                entity.Property(g => g.Result)
                      .IsRequired()
                      .IsUnicode();

                entity.HasOne(g => g.HomeTeam)
                      .WithMany(t => t.HomeGames)
                      .HasForeignKey(g => g.HomeTeamId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(g => g.AwayTeam)
                      .WithMany(t => t.AwayGames)
                      .HasForeignKey(g => g.AwayTeamId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Bet>(entity =>
            {
                entity.HasKey(x => x.BetId);

                entity.Property(x => x.Amount).IsRequired();

                entity.Property(x => x.Prediction).IsRequired();

                entity.Property(x => x.DateTime).IsRequired();

                entity.HasOne(b => b.User)
                      .WithMany(u => u.Bets)
                      .HasForeignKey(b => b.UserId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(b => b.Game)
                      .WithMany(g => g.Bets)
                      .HasForeignKey(b => b.GameId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(x => x.UserId);

                entity.Property(u => u.Username)
                      .IsRequired()
                      .IsUnicode(false)
                      .HasMaxLength(100);

                entity.Property(u => u.Password)
                      .IsRequired();

                entity.Property(u => u.Email)
                      .IsRequired();

                entity.Property(u => u.Password)
                      .IsUnicode(true);
            });
        }
    }
}
