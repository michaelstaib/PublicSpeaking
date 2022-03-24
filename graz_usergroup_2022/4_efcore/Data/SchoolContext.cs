using Microsoft.EntityFrameworkCore;

namespace Demo.Data;

public class SchoolContext : DbContext
{
    public SchoolContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Student> Students => Set<Student>();

    public DbSet<Enrollment> Enrollments => Set<Enrollment>();

    public DbSet<Course> Courses => Set<Course>();

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