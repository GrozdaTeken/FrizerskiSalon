using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Rezervacija> Rezervacije { get; set; }
        public DbSet<Frizer> Frizeri { get; set; }
        public DbSet<MessageQueue> MessageQueues { get; set; }
        public DbSet<Blacklist> Blacklists { get; set; }
        public DbSet<Smena> Smene { get; set; }
        public DbSet<Godisnji> Godisnji { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Rezervacija - Frizer (1:N)
            modelBuilder.Entity<Rezervacija>()
                .HasOne(r => r.Frizer)
                .WithMany(f => f.Rezervacije)
                .HasForeignKey(r => r.FriId)
                .OnDelete(DeleteBehavior.Cascade);

            // Smena - Frizer (1:N)
            modelBuilder.Entity<Smena>()
                .HasOne(s => s.Frizer)
                .WithMany()
                .HasForeignKey(s => s.FriId)
                .OnDelete(DeleteBehavior.Cascade);

            // MessageQueue - Rezervacija (1:N)
            modelBuilder.Entity<MessageQueue>()
                .HasOne(m => m.Rezervacija)
                .WithMany(r => r.MessageQueues)
                .HasForeignKey(m => m.RezId)
                .OnDelete(DeleteBehavior.Cascade);

            // Frizer - Godisnji (1:N)
            modelBuilder.Entity<Godisnji>()
                .HasOne(g => g.Frizer)
                .WithMany()
                .HasForeignKey(g => g.FriId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
