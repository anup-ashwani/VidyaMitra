namespace VidyaMitra.Domain.Entities;

public class Student : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string StudentRollNumber { get; set; } = string.Empty; // Unique Identifier
    public string IdentityUserId { get; set; } = string.Empty; // Direct link to AspNetUsers table
    public int DepartmentId { get; set; }

    // Navigation Properties
    public Department? Department { get; set; }
    public ICollection<Enrollment> Enrollments { get; set; } = [];
}
