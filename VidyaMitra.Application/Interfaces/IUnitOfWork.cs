namespace VidyaMitra.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IStudentRepository Students { get; }
    ICourseRepository Courses { get; }
    // Add other specific repositories here as your project grows (e.g., IProfessorRepository)
    
    Task<int> CompleteAsync(); // Wrapper for SaveChangesAsync
}