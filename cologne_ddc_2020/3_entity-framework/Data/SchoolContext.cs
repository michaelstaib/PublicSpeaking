using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ContosoUni.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }

        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=chat.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany(t => t.Enrollments)
                .WithOne(t => t.Student)
                .HasForeignKey(t => t.StudentId);

            modelBuilder.Entity<Enrollment>()
                .HasIndex(t => new { t.StudentId, t.CourseId })
                .IsUnique();

            modelBuilder.Entity<Course>()
                .HasMany(t => t.Enrollments)
                .WithOne(t => t.Course)
                .HasForeignKey(t => t.CourseId);
        }
    }
}