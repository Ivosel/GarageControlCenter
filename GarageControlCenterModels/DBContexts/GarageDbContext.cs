using GarageControlCenterBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace GarageControlCenterBackend.DBContexts
{
    public class GarageDbContext : DbContext
    {
        public DbSet<Garage> Garages { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<ParkingSpot> ParkingSpots { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<GarageUser> Users { get; set; }
        public DbSet<UserTicket> UserTickets { get; set; }

        public GarageDbContext(DbContextOptions<GarageDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureGarageEntity(modelBuilder);
            ConfigureLevelEntity(modelBuilder);
            ConfigureUserEntity(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureGarageEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Garage>()
                .HasMany(g => g.Levels)
                .WithOne(l => l.GarageRef)
                .HasForeignKey(l => l.GarageId);

            modelBuilder.Entity<Garage>()
                .HasMany(g => g.Tickets)
                .WithOne(t => t.GarageRef)
                .HasForeignKey(t => t.GarageId);

            modelBuilder.Entity<Garage>()
                .HasMany(g => g.Users)
                .WithOne(u => u.GarageRef)
                .HasForeignKey(u => u.GarageId);
        }

        private void ConfigureLevelEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Level>()
                .HasMany(l => l.Spots)
                .WithOne(s => s.LevelRef)
                .HasForeignKey(s => s.LevelId);
        }

        private void ConfigureUserEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GarageUser>()
                .HasOne(u => u.UserTicket)
                .WithOne(ut => ut.UserRef)
                .HasForeignKey<UserTicket>(ut => ut.UserId);
        }
    }
}
