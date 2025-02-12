using AcerteOGrid.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcerteOGrid.Infrastructure.DataAccess
{
    internal class AcerteOGridDbContex : DbContext
    {
        public AcerteOGridDbContex(DbContextOptions options) : base(options) { }

        public DbSet<UserTypeEntity> AOG_TB_TIPO_USUARIO { get; set; }
        public DbSet<UserEntity> AOG_TB_USUARIO { get; set; }
        public DbSet<PilotEntity> AOG_TB_PILOTO { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTypeEntity>().ToTable("AOG_TB_TIPO_USUARIO");
            modelBuilder.Entity<UserEntity>().ToTable("AOG_TB_USUARIO");
            modelBuilder.Entity<PilotEntity>().ToTable("AOG_TB_PILOTO");

            modelBuilder.Entity<UserTypeEntity>(entity =>
            {
                entity.Property(u => u.Id).HasColumnName("TIPUSUID");
                entity.Property(u => u.Name).HasColumnName("TIPUSUNOM");
                entity.Property(u => u.Administrator).HasColumnName("TIPUSUADM");
                entity.Property(u => u.Maintenance).HasColumnName("TIPUSUMAN");
            });

            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.Property(u => u.Id).HasColumnName("USUID");
                entity.Property(u => u.UserTypeEntityId).HasColumnName("TIPID");
                entity.Property(u => u.Name).HasColumnName("USUNOM");
                entity.Property(u => u.Email).HasColumnName("USUMAI");
                entity.Property(u => u.Password).HasColumnName("USUSEN");
                entity.Property(u => u.Identifier).HasColumnName("USUIDE");
            });

            modelBuilder.Entity<PilotEntity>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("PILID");
                entity.Property(e => e.Name).HasColumnName("PILNOM");
                entity.Property(e => e.ShortName).HasColumnName("PILNOMRED");
                entity.Property(e => e.DateOfBirth).HasColumnName("PILDATNAS");
                entity.Property(e => e.DateOfDeath).HasColumnName("PILDATFAL");
                entity.Property(e => e.GenderType).HasColumnName("PILSEX").HasColumnType("BIT");
                entity.Property(e => e.UserInclusion).HasColumnName("USUINC");
                entity.Property(e => e.DateInclusion).HasColumnName("DATINC");
                entity.Property(e => e.UserChange).HasColumnName("USUALT");
                entity.Property(e => e.DateChange).HasColumnName("DATALT");
            });
        }
    }
}
