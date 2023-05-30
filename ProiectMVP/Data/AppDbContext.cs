using System.ComponentModel.DataAnnotations.Schema;
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
        public DbSet<GroupCourse> GroupCourses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Absence> Absences { get; set; }
        public DbSet<StudyMaterial> StudyMaterials { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Average> Averages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("highSchool");

            //Student
            modelBuilder.Entity<Student>()
                .HasOne(e => e.Group)
                .WithMany(c => c.Students)
                .HasForeignKey(e => e.GroupId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Student>()
                .HasOne(e => e.User)
                .WithOne(u => u.Student)
                .HasForeignKey<Student>(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            //Group
            modelBuilder.Entity<Group>()
                .HasMany(e => e.Students)
                .WithOne(s => s.Group)
                .HasForeignKey(s => s.GroupId);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.GroupCourses)
                .WithOne(gc => gc.Group)
                .HasForeignKey(gc => gc.GroupId);

            modelBuilder.Entity<Group>()
                .HasOne(e => e.ClassMaster)
                .WithOne(t => t.Group)
                .HasForeignKey<Group>(e => e.ClassMasterId)
                .OnDelete(DeleteBehavior.Restrict);


            //Course
            modelBuilder.Entity<Course>()
                .HasMany(s => s.StudyMaterials)
                .WithOne(sm => sm.Course)
                .HasForeignKey(sm => sm.CourseId);

            modelBuilder.Entity<Course>()
                .HasMany(s => s.GroupCourses)
                .WithOne(ps => ps.Course)
                .HasForeignKey(ps => ps.CourseId);

            //GroupCourse
            modelBuilder.Entity<GroupCourse>()
                .HasKey(gc => new {gc.GroupId, gc.CourseId});

            //Grade
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Course)
                .WithMany(c => c.Grades)
                .HasForeignKey(g => g.CourseId);

            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Student)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.StudentId);

            //Average
            modelBuilder.Entity<Average>()
                .HasOne(a => a.Course)
                .WithMany(c => c.Averages)
                .HasForeignKey(a => a.CourseId);
            modelBuilder.Entity<Average>()
                .HasOne(a => a.Student)
                .WithMany(s => s.Averages)
                .HasForeignKey(a => a.StudentId);

            //Absence
            modelBuilder.Entity<Absence>()
                .HasOne(a => a.Course)
                .WithMany(c => c.Absences)
                .HasForeignKey(a => a.CourseId);

            modelBuilder.Entity<Absence>()
                .HasOne(a => a.Student)
                .WithMany(s => s.Absences)
                .HasForeignKey(a => a.StudentId);

            //Teacher

            modelBuilder.Entity<Teacher>()
                .HasOne(e => e.User)
                .WithOne(u => u.Teacher)
                .HasForeignKey<Teacher>(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.Courses)
                .WithOne(c => c.Teacher)
                .HasForeignKey(c => c.TeacherId);

            //User
            modelBuilder.Entity<User>()
                .Property(d => d.Role)
                .HasConversion(new EnumToStringConverter<UserRole>());
        }
    }
}