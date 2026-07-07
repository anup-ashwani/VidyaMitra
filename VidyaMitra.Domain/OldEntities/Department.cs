namespace VidyaMitra.Domain.Entities;

public class Department : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty; // e.g., "CS", "MECH"

    // Navigation Properties
    public ICollection<Course> Courses { get; set; } = [];
    public ICollection<Professor> Professors { get; set; } = [];
}
