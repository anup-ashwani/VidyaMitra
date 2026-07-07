using VidyaMitra.Domain.Enums;
namespace VidyaMitra.Domain.Entities;

public class Enrollment : BaseEntity
{
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public string AcademicYear { get; set; } = string.Empty; // e.g., "2026-2027"
    public Grade CourseGrade { get; set; } = Grade.Ongoing;

    // Navigation Properties
    public Student? Student { get; set; }
    public Course? Course { get; set; }
}
