using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DepozitApp
{
    public partial class DepozitContext : DbContext
    {
        public DepozitContext()
        {
        }

        public DepozitContext(DbContextOptions<DepozitContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Command> Commands { get; set; } = null!;
        public virtual DbSet<Produ> Produs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=127.0.0.1,1423;Database=Depozit;User Id=sa;Password=MoldovaN92#!;");
               // optionsBuilder.UseSqlServer("Server=127.0.0.1,1423;Database=Depozit;User Id=sa;Password=MoldovaN92#!;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Command>(entity =>
            {
                entity.ToTable("Command");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CommandId).HasColumnName("Command_Id");

                entity.Property(e => e.CountProdus).HasColumnName("Count_Produs");

                entity.Property(e => e.DataChange).HasColumnType("date");

                entity.HasOne(d => d.CommandNavigation)
                    .WithMany(p => p.Commands)
                    .HasForeignKey(d => d.CommandId)
                    .HasConstraintName("FK__Command__Command__276EDEB3");
            });

            modelBuilder.Entity<Produ>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                
                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Owner)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
