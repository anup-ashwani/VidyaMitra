namespace VidyaMitra.Domain.Entities;

public class Professor : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string EmployeeId { get; set; } = string.Empty; // Unique Identifier
    public string IdentityUserId { get; set; } = string.Empty; // Direct link to AspNetUsers table
    public int DepartmentId { get; set; }

    // Navigation Properties
    public Department? Department { get; set; }
    public ICollection<Course> TaughtCourses { get; set; } = new List<Course>();
}
