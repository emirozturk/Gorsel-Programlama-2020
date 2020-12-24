using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Veritabani.Models
{
    public partial class SongsDbContext : DbContext
    {
        public SongsDbContext()
        {
        }

        public SongsDbContext(DbContextOptions<SongsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Sanatci> Sanatcis { get; set; }
        public virtual DbSet<SanatciSarki> SanatciSarkis { get; set; }
        public virtual DbSet<Sarki> Sarkis { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=SongsDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<Sanatci>(entity =>
            {
                entity.ToTable("sanatci");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("adi");
            });

            modelBuilder.Entity<SanatciSarki>(entity =>
            {
                entity.ToTable("sanatciSarki");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.SanatciId).HasColumnName("sanatciId");

                entity.Property(e => e.SarkiId).HasColumnName("sarkiId");

                entity.HasOne(d => d.Sanatci)
                    .WithMany(p => p.SanatciSarkis)
                    .HasForeignKey(d => d.SanatciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sanatciSarki_sanatci");

                entity.HasOne(d => d.Sarki)
                    .WithMany(p => p.SanatciSarkis)
                    .HasForeignKey(d => d.SarkiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sanatciSarki_sarki");
            });

            modelBuilder.Entity<Sarki>(entity =>
            {
                entity.ToTable("sarki");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("adi");

                entity.Property(e => e.CikisTarihi)
                    .HasColumnType("date")
                    .HasColumnName("cikisTarihi");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
