using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MIMM_Shared.Models
{
    public partial class mimmContext : DbContext
    {
        public mimmContext()
        {
        }

        public mimmContext(DbContextOptions<mimmContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Albums> Albums { get; set; }
        public virtual DbSet<Artists> Artists { get; set; }
        public virtual DbSet<Feelings> Feelings { get; set; }
        public virtual DbSet<Songs> Songs { get; set; }
        public virtual DbSet<Tracks> Tracks { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Albums>(entity =>
            {
                entity.ToTable("albums");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Idartist)
                    .HasColumnName("idartist")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)")
                    .HasDefaultValueSql("''")
                    .HasCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");
            });

            modelBuilder.Entity<Artists>(entity =>
            {
                entity.ToTable("artists");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)")
                    .HasDefaultValueSql("''")
                    .HasCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");
            });

            modelBuilder.Entity<Feelings>(entity =>
            {
                entity.ToTable("feelings");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");
            });

            modelBuilder.Entity<Songs>(entity =>
            {
                entity.ToTable("songs");

                entity.HasIndex(e => e.Idtracks)
                    .HasName("FK_songs_idtracks");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Idfeeling)
                    .HasColumnName("idfeeling")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Idtracks)
                    .HasColumnName("idtracks")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Whispertime)
                    .HasColumnName("whispertime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.IdtracksNavigation)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.Idtracks)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_songs_idtracks");
            });

            modelBuilder.Entity<Tracks>(entity =>
            {
                entity.ToTable("tracks");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Idalbum)
                    .HasColumnName("idalbum")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasDefaultValueSql("''")
                    .HasCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Email)
                    .HasName("PRIMARY");

                entity.ToTable("users");

                entity.HasIndex(e => e.Id)
                    .HasName("id")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(100)")
                    .HasCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasColumnType("varchar(255)")
                    .HasCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11) unsigned zerofill");

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasColumnType("varchar(255)")
                    .HasCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("varchar(255)")
                    .HasCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
