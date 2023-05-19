using Microsoft.EntityFrameworkCore;
using ProiectMVP.Models;

namespace ProiectMVP.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Elev> Elevi { get; set; }
        public DbSet<Clasa> Clase { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("liceu");

            modelBuilder.Entity<Elev>()
                .HasOne(e => e.Clasa)
                .WithMany(c => c.Elevi)
                .HasForeignKey(e => e.ClasaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ElevMaterie>()
                .HasKey(em => new { em.ElevId, em.MaterieId });

            modelBuilder.Entity<ElevMaterie>()
                .HasOne(em => em.Elev)
                .WithMany(e => e.EleviMaterii)
                .HasForeignKey(em => em.ElevId);

            modelBuilder.Entity<ElevMaterie>()
                .HasOne(em => em.Materie)
                .WithMany(m => m.EleviMaterii)
                .HasForeignKey(em => em.MaterieId);

            modelBuilder.Entity<Profesor>()
                .HasMany(p => p.Materii)
                .WithMany(m => m.Profesori);

            modelBuilder.Entity<Profesor>()
                .HasOne(p => p.ClasaDiriginte)
                .WithOne(c => c.ProfesorDiriginte)
                .HasForeignKey<Profesor>(p => p.ClasaDiriginteId)
                .OnDelete(DeleteBehavior.Cascade);



        }
    }
}
