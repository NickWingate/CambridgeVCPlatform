using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApi.Data
{
    public partial class CVCPlatformDbContext : DbContext
    {
        public CVCPlatformDbContext()
        {
        }

        public CVCPlatformDbContext(DbContextOptions<CVCPlatformDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;
        public virtual DbSet<SessionTiming> SessionTimings { get; set; } = null!;
        public virtual DbSet<Squad> Squads { get; set; } = null!;
        public virtual DbSet<TrainingSession> TrainingSessions { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.County).HasMaxLength(200);

                entity.Property(e => e.LineOne).HasMaxLength(200);

                entity.Property(e => e.LineTwo).HasMaxLength(200);

                entity.Property(e => e.PostCode).HasMaxLength(200);

                entity.Property(e => e.Town).HasMaxLength(200);
            });

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable("ApplicationUser");

                entity.HasIndex(e => e.NormalizedEmail, "IX_ApplicationUser_NormalizedEmail");

                entity.HasIndex(e => e.NormalizedUserName, "IX_ApplicationUser_NormalizedUserName");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<SessionTiming>(entity =>
            {
                entity.Property(e => e.End).HasColumnType("datetime");

                entity.Property(e => e.Start).HasColumnType("datetime");
            });

            modelBuilder.Entity<Squad>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<TrainingSession>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(500);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Address)
                    .WithMany()
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_TrainingSessions_Addresses");

                entity.HasOne(d => d.SessionTiming)
                    .WithMany()
                    .HasForeignKey(d => d.SessionTimingId)
                    .HasConstraintName("FK_TrainingSessions_SessionTimings");

                entity.HasOne(d => d.Squad)
                    .WithMany()
                    .HasForeignKey(d => d.SquadId)
                    .HasConstraintName("FK_TrainingSessions_Squads");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
