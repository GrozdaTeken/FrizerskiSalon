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

            // Konfiguracija za entitet Blacklist
            modelBuilder.Entity<Blacklist>(entity =>
            {
                entity.Property(e => e.Email)
                    .HasMaxLength(45)
                    .IsRequired();

                entity.Property(e => e.Telefon)
                    .HasMaxLength(45)
                    .IsRequired();

                entity.Property(e => e.Razlog)
                    .HasMaxLength(45)
                    .IsRequired();

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime2")
                    .IsRequired();
            });

            // Konfiguracija za entitet Frizer
            modelBuilder.Entity<Frizer>(entity =>
            {
                entity.Property(e => e.Ime)
                .HasMaxLength(45)
                .IsRequired();

                entity.Property(e => e.Prezime)
                .HasMaxLength(45)
                .IsRequired();

                entity.Property(e => e.Telefon)
                .HasMaxLength(45)
                .IsRequired();
            });

            // Konfiguracija za entitet Godisnji
            modelBuilder.Entity<Godisnji>(entity =>
            {
                entity.Property(e => e.GodisnjiOd)
                .HasColumnType("datetime2")
                .IsRequired();

                entity.Property(e => e.GodisnjiDo)
                .HasColumnType("datetime2")
                .IsRequired();
            });

            // Konfiguracija za entitet MessageQueue
            modelBuilder.Entity<MessageQueue>(entity =>
            {
                entity.Property(e => e.Receiver)
                .HasMaxLength(45)
                .IsRequired();

                entity.Property(e => e.Sender)
                .HasMaxLength(45)
                .IsRequired();

                entity.Property(e => e.Time)
                .HasColumnType("datetime2")
                .IsRequired();

                entity.Property(e => e.MessageSubject)
                .HasMaxLength(45)
                .IsRequired();

                entity.Property(e => e.Content)
                .HasColumnType("nvarchar(max)")
                .IsRequired();

                entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsRequired();
            });

            // Konfiguracija za entitet Rezervacija
            modelBuilder.Entity<Rezervacija>(entity =>
            {
                entity.Property(e => e.Termin)
                .HasColumnType("datetime2")
                .IsRequired();

                entity.Property(e => e.Ime)
                .HasMaxLength(45)
                .IsRequired();

                entity.Property(e => e.Mail)
                .HasMaxLength(45)
                .IsRequired();

                entity.Property(e => e.Telefon)
                .HasMaxLength(45)
                .IsRequired();
            });

            // Konfiguracija za entitet Smena
            modelBuilder.Entity<Smena>(entity =>
            {
                entity.Property(e => e.Pocetak)
                .HasColumnType("datetime2")
                .IsRequired();

                entity.Property(e => e.Kraj)
                .HasColumnType("datetime2")
                .IsRequired();
            });


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
