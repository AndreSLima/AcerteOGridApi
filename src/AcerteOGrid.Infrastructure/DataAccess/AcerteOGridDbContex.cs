using AcerteOGrid.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcerteOGrid.Infrastructure.DataAccess
{
    internal class AcerteOGridDbContex : DbContext
    {
        public AcerteOGridDbContex(DbContextOptions options) : base(options) { }

        public DbSet<PilotEntity> AOG_TB_PILOTO { get; set; }
        public DbSet<UserEntity> AOG_TB_USUARIO { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PilotEntity>().ToTable("AOG_TB_PILOTO");
            modelBuilder.Entity<UserEntity>().ToTable("AOG_TB_USUARIO");

            modelBuilder.Entity<PilotEntity>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("PILID");
                entity.Property(e => e.Name).HasColumnName("PILNOM");
                entity.Property(e => e.ShortName).HasColumnName("PILNOMRED");
                entity.Property(e => e.DateOfBirth).HasColumnName("PILDATNAS");
                entity.Property(e => e.DateOfDeath).HasColumnName("PILDATFAL");
                entity.Property(e => e.GenderType).HasColumnName("PILSEX").HasColumnType("BIT");
                entity.Property(e => e.UseInc).HasColumnName("USUINC");
                entity.Property(e => e.DatInc).HasColumnName("DATINC");
            });

            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.Property(u => u.Id).HasColumnName("USUID");
                entity.Property(u => u.Name).HasColumnName("USUNOM");
                entity.Property(u => u.Email).HasColumnName("USUMAI");
                entity.Property(u => u.Password).HasColumnName("USUSEN");
                entity.Property(u => u.Identifier).HasColumnName("USUIDE");
                entity.Property(u => u.Role).HasColumnName("USUNIV");
            });
        }
    }
}
