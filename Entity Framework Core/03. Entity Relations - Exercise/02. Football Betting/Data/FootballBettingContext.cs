using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionInfo.ConnectionString);
        }

        public FootballBettingContext() { }

        public FootballBettingContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Bet> Bets { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Country
            modelBuilder.Entity<Country>().HasKey(c => c.CountryId);
            modelBuilder.Entity<Country>().Property(c => c.Name).IsRequired();
            modelBuilder.Entity<Country>().HasMany(c => c.Towns).WithOne(t => t.Country);

            //Town
            modelBuilder.Entity<Town>().HasKey(t => t.TownId);
           modelBuilder.Entity<Town>().Property(t => t.Name).IsRequired();
           modelBuilder.Entity<Town>().HasOne(t => t.Country).WithMany(c => c.Towns)
               .HasForeignKey(t => t.CountryId);
           modelBuilder.Entity<Town>().HasMany(t => t.Teams).WithOne(te => te.Town);

            //Positions
            modelBuilder.Entity<Position>().HasKey(po => po.PositionId);
           modelBuilder.Entity<Position>().Property(po => po.Name).IsRequired();
           modelBuilder.Entity<Position>().HasMany(po => po.Players).WithOne(p => p.Position);

            //Players
            modelBuilder.Entity<Player>().HasKey(p => p.PlayerId);
            modelBuilder.Entity<Player>().Property(p => p.IsInjured).IsRequired().HasColumnType("bit");
            modelBuilder.Entity<Player>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Player>().HasOne(p => p.Team).WithMany(t => t.Players).HasForeignKey(p => p.TeamId);
            modelBuilder.Entity<Player>().HasOne(p => p.Position).WithMany(po => po.Players)
              .HasForeignKey(p => p.PositionId);

            //PlayerStatistics - mapped automatically via navigation collection properties
            modelBuilder.Entity<PlayerStatistic>().HasKey(ps => new { ps.PlayerId, ps.GameId });
            modelBuilder.Entity<PlayerStatistic>().HasOne(e => e.Game)
                .WithMany(g => g.PlayerStatistics)
                .HasForeignKey(e => e.GameId);

            modelBuilder.Entity<PlayerStatistic>().HasOne(e => e.Player)
                .WithMany(p => p.PlayerStatistics)
                .HasForeignKey(e => e.PlayerId);

            // Team
            modelBuilder.Entity<Team>().HasKey(t => t.TeamId);
           modelBuilder.Entity<Team>().HasOne(t => t.PrimaryKitColor).WithMany(c => c.PrimaryKitTeams).HasForeignKey(t=> t.PrimaryKitColorId);//.OnDelete(DeleteBehavior.NoAction);
           modelBuilder.Entity<Team>().HasOne(t => t.SecondaryKitColor).WithMany(c => c.SecondaryKitTeams)
               .HasForeignKey(t => t.SecondaryKitColorId);//.OnDelete(DeleteBehavior.NoAction);
           modelBuilder.Entity<Team>().HasOne(t => t.Town).WithMany(to => to.Teams);

            //Game - mapped via inverse property attribute in Game and Team
            modelBuilder.Entity<Game>().HasKey(g => g.GameId);
            modelBuilder.Entity<Game>().HasOne(g => g.AwayTeam).WithMany(at => at.AwayGames)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Game>().HasOne(g => g.HomeTeam).WithMany(ht => ht.HomeGames)
                .OnDelete(DeleteBehavior.NoAction);

            //Bet
            modelBuilder.Entity<Bet>().HasKey(b => b.BetId);
            modelBuilder.Entity<Bet>().HasOne(b => b.Game).WithMany(g => g.Bets);
            modelBuilder.Entity<Bet>().HasOne(b => b.User).WithMany(u => u.Bets);


        }

    }
}