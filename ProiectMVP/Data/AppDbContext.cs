using Microsoft.EntityFrameworkCore;
using ProiectMVP.Models;

namespace ProiectMVP.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Absence> Absences { get; set; }
        public DbSet<StudyMaterial> StudyMaterials { get; set; }
        public DbSet<ProfessorSubject> ProfessorSubjects { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("highSchool");

            modelBuilder.Entity<Student>()
                .HasOne(e => e.Class)
                .WithMany(c => c.Students)
                .HasForeignKey(e => e.ClassId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.StudentSubjects)
                .WithOne(em => em.Student)
                .HasForeignKey(em => em.UserId);

            modelBuilder.Entity<StudentSubject>()
                .HasKey(em => new { em.Id });

            modelBuilder.Entity<StudentSubject>()
                .HasOne(em => em.Student)
                .WithMany(e => e.StudentSubjects)
                .HasForeignKey(em => em.UserId);

            modelBuilder.Entity<StudentSubject>()
                .HasOne(em => em.Subject)
                .WithMany(m => m.StudentSubjects)
                .HasForeignKey(em => em.SubjectId);

            modelBuilder.Entity<Subject>()
                .HasMany(s => s.StudyMaterials)
                .WithOne(sm => sm.Subject)
                .HasForeignKey(sm => sm.SubjectId);

            modelBuilder.Entity<Subject>()
                .HasMany(s => s.ProfessorSubjects)
                .WithOne(ps => ps.Subject)
                .HasForeignKey(ps => ps.SubjectId);

            modelBuilder.Entity<Grade>()
                .HasOne(g => g.StudentSubject)
                .WithMany(ss => ss.Grades)
                .HasForeignKey(g => g.StudentSubjectId);

            modelBuilder.Entity<Absence>()
                .HasOne(a => a.StudentSubject)
                .WithMany(ss => ss.Absences)
                .HasForeignKey(a => a.StudentSubjectId);

            modelBuilder.Entity<Professor>()
                .HasMany(e => e.ProfessorSubjects)
                .WithOne(em => em.Professor)
                .HasForeignKey(em => em.UserId);

            modelBuilder.Entity<Semester>()
                .HasMany(s => s.StudentSubjects)
                .WithOne(ss => ss.Semester)
                .HasForeignKey(ss => ss.SemesterId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasDiscriminator<UserRole>("Role");

            modelBuilder.Entity<Student>()
                .HasOne(e => e.User)
                .WithOne(c => c.Id)
                .HasForeignKey<User>(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Professor>()
                .HasOne(e => e.ProfessorUser)
                .WithOne(c => c.Professor)
                .HasForeignKey<User>(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}