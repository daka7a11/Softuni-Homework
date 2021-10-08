using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;
using System;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {
        }

        public StudentSystemContext(DbContextOptions<StudentSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Homework> HomeworkSubmissions { get; set; }
        public virtual DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-Q72FB2M\SQLEXPRESS;Database=Student System;Integrated Security=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(x => x.StudentId);

                entity.Property(x => x.Name)
                      .IsRequired()
                      .IsUnicode(true)
                      .HasMaxLength(100);

                entity.Property(x => x.PhoneNumber)
                      .IsRequired(false)
                      .IsUnicode(false)
                      .HasDefaultValueSql("CHAR(10)");

                entity.Property(x => x.RegisteredOn)
                      .IsRequired();

                entity.Property(x => x.Birthday)
                      .IsRequired(false);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(x => x.CourseId);

                entity.Property(x => x.Name)
                      .IsRequired()
                      .HasMaxLength(80)
                      .IsUnicode(true);

                entity.Property(x => x.Description)
                      .IsRequired(false)
                      .IsUnicode(true);

                entity.Property(x => x.StartDate)
                      .IsRequired();

                entity.Property(x => x.EndDate)
                      .IsRequired();

                entity.Property(x => x.Price)
                      .IsRequired();
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(x => x.ResourceId);

                entity.Property(x => x.Name)
                      .IsRequired()
                      .HasMaxLength(50)
                      .IsUnicode(true);

                entity.Property(x => x.Url)
                      .IsUnicode(false)
                      .IsRequired();

                entity.Property(x => x.ResourceType)
                      .IsRequired();

                entity.HasOne(r => r.Course)
                      .WithMany(c => c.Resources)
                      .HasForeignKey(r => r.CourseId);
            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity.HasKey(x => x.HomeworkId);

                entity.Property(h => h.Content)
                      .IsRequired()
                      .IsUnicode(false);

                entity.Property(x => x.ContentType)
                      .IsRequired();

                entity.Property(x => x.SubmissionTime)
                     .IsRequired();

                entity.HasOne(h => h.Student)
                      .WithMany(s => s.HomeworkSubmissions)
                      .HasForeignKey(h => h.StudentId);

                entity.HasOne(h => h.Course)
                      .WithMany(c => c.HomeworkSubmissions)
                      .HasForeignKey(h => h.CourseId);
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(x => new { x.StudentId, x.CourseId });

                entity.HasOne(st => st.Student)
                      .WithMany(s => s.CourseEnrollments)
                      .HasForeignKey(st => st.StudentId);

                entity.HasOne(st => st.Course)
                      .WithMany(c => c.StudentsEnrolled)
                      .HasForeignKey(st => st.CourseId);
            });
        }
    }
}
