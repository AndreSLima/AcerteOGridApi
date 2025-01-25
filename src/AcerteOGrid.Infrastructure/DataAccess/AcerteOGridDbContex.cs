using AcerteOGrid.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AcerteOGrid.Infrastructure.DataAccess
{
    internal class AcerteOGridDbContex : DbContext
    {
        public AcerteOGridDbContex(DbContextOptions options) : base(options) { }

        public DbSet<PilotEntity> AOG_TB_PILOTO { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PilotEntity>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("PILID");
                entity.Property(e => e.Name).HasColumnName("PILNOM");
                entity.Property(e => e.ShortName).HasColumnName("PILNOMRED");
                entity.Property(e => e.DateOfBirth).HasColumnName("PILDATNAS");
                entity.Property(e => e.DateOfDeath).HasColumnName("PILDATFAL");
                entity.Property(e => e.GenderType).HasColumnName("PILSEX");
            });
        }
    }
}
