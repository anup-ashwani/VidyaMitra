namespace VidyaMitra.Domain.Entities;

public class Course : BaseEntity
{
    public string Code { get; set; } = string.Empty; // e.g., "CS101"
    public string Title { get; set; } = string.Empty;
    public int Credits { get; set; }
    public int DepartmentId { get; set; }
    public int? ProfessorId { get; set; } // Nullable if no professor is assigned yet

    // Navigation Properties
    public Department? Department { get; set; }
    public Professor? Professor { get; set; }
    public ICollection<Enrollment> StudentEnrollments { get; set; } = new List<Enrollment>();
}
