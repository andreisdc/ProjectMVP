using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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
        public DbSet<Group> Groups { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Absence> Absences { get; set; }
        public DbSet<StudyMaterial> StudyMaterials { get; set; }
        public DbSet<TeacherCourse> TeacherCourses { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("highSchool");

            //Student

            modelBuilder.Entity<Student>()
                .HasOne(e => e.Group)
                .WithMany(c => c.Students)
                .HasForeignKey(e => e.ClassId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.StudentSubjects)
                .WithOne(em => em.Student)
                .HasForeignKey(em => em.UserId);

            modelBuilder.Entity<Student>()
                .HasOne(e => e.User)
                .WithOne(u => u.Student)
                .HasForeignKey<Student>(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);


            //StudentCourse

            modelBuilder.Entity<StudentCourse>()
                .HasKey(em => new { em.Id });

            modelBuilder.Entity<StudentCourse>()
                .HasOne(em => em.Student)
                .WithMany(e => e.StudentSubjects)
                .HasForeignKey(em => em.UserId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(em => em.Course)
                .WithMany(m => m.StudentSubjects)
                .HasForeignKey(em => em.SubjectId);

            //Course

            modelBuilder.Entity<Course>()
                .HasMany(s => s.StudyMaterials)
                .WithOne(sm => sm.Course)
                .HasForeignKey(sm => sm.SubjectId);

            modelBuilder.Entity<Course>()
                .HasMany(s => s.ProfessorSubjects)
                .WithOne(ps => ps.Course)
                .HasForeignKey(ps => ps.SubjectId);

            modelBuilder.Entity<Course>()
                .HasMany(s => s.StudentSubjects)
                .WithOne(ss => ss.Course)
                .HasForeignKey(ss => ss.SubjectId);

            //Grade

            modelBuilder.Entity<Grade>()
                .HasOne(g => g.StudentCourse)
                .WithMany(ss => ss.Grades)
                .HasForeignKey(g => g.StudentSubjectId);

            //Absence

            modelBuilder.Entity<Absence>()
                .HasOne(a => a.StudentCourse)
                .WithMany(ss => ss.Absences)
                .HasForeignKey(a => a.StudentSubjectId);

            //Teacher

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.ProfessorSubjects)
                .WithOne(em => em.Teacher)
                .HasForeignKey(em => em.UserId);

            modelBuilder.Entity<Teacher>()
                .HasOne(e => e.User)
                .WithOne(u => u.Teacher)
                .HasForeignKey<Teacher>(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);


            //Semester

            modelBuilder.Entity<Semester>()
                .HasMany(s => s.StudentSubjects)
                .WithOne(ss => ss.Semester)
                .HasForeignKey(ss => ss.SemesterId)
                .OnDelete(DeleteBehavior.Restrict);

            //User
            modelBuilder.Entity<User>()
                .Property(d => d.Role)
                .HasConversion(new EnumToStringConverter<UserRole>());
        }
    }
}