using Microsoft.EntityFrameworkCore;
using VidyaMitra.Domain.Entities;

namespace VidyaMitra.Repository.Data;

public class AppDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // 1. Setup Composite Primary Key for Enrollment table
        builder.Entity<Enrollment>()
            .HasKey(e => new { e.StudentId, e.CourseId });

        // 2. Map Student side of Enrollment join
        builder.Entity<Enrollment>()
            .HasOne(e => e.Student)
            .WithMany(s => s.Enrollments)
            .HasForeignKey(e => e.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        // 3. Map Course side of Enrollment join
        builder.Entity<Enrollment>()
            .HasOne(e => e.Course)
            .WithMany(c => c.StudentEnrollments)
            .HasForeignKey(e => e.CourseId)
            .OnDelete(DeleteBehavior.Cascade);
            
        // 4. Enforce unique index rules for roll numbers and employee IDs
        builder.Entity<Student>()
            .HasIndex(s => s.StudentRollNumber)
            .IsUnique();

        builder.Entity<Professor>()
            .HasIndex(p => p.EmployeeId)
            .IsUnique();
    }
}
