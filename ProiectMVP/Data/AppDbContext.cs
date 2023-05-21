using Microsoft.EntityFrameworkCore;
using ProiectMVP.Models;

namespace ProiectMVP.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("highSchool");

            modelBuilder.Entity<Student>()
                .HasOne(e => e.Class)
                .WithMany(c => c.Students)
                .HasForeignKey(e => e.ClassId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StudentSubject>()
                .HasKey(em => new { ElevId = em.StudentId, MaterieId = em.SubjectId });

            modelBuilder.Entity<StudentSubject>()
                .HasOne(em => em.Student)
                .WithMany(e => e.StudentSubjects)
                .HasForeignKey(em => em.StudentId);

            modelBuilder.Entity<StudentSubject>()
                .HasOne(em => em.Subject)
                .WithMany(m => m.StudentSubjects)
                .HasForeignKey(em => em.SubjectId);

            modelBuilder.Entity<Professor>()
                .HasMany(p => p.Subjects)
                .WithMany(m => m.Professors);

            modelBuilder.Entity<Professor>()
                .HasOne(p => p.ClassMaster)
                .WithOne(c => c.ClassMaster)
                .HasForeignKey<Professor>(p => p.ClassMasterId)
                .OnDelete(DeleteBehavior.Cascade);



        }
    }
}
