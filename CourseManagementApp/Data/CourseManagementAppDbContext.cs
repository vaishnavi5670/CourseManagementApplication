using CourseManagementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementApp.Data
{
    public class CourseManagementAppDbContext : DbContext
    {
        public CourseManagementAppDbContext(DbContextOptions<CourseManagementAppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Admin> Admins { get; set; } = null!;
        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<StudentEnrollment> StudentEnrollments { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // some sample Fluent API configuration
            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.Fee).HasColumnType("decimal(18,2)");
                entity.HasIndex(e => e.Title).IsUnique(false);
            });


            modelBuilder.Entity<StudentEnrollment>(entity =>
            {
                entity.HasOne(e => e.Student)
                .WithMany(s => s.StudentEnrollments)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Cascade);


                entity.HasOne(e => e.Course)
                .WithMany(c => c.StudentEnrollment)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Cascade);


                entity.HasIndex(e => new { e.StudentId, e.CourseId }).IsUnique(true);
            });
        }
    }
    }
