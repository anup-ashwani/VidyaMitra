using VidyaMitra.Domain.Entities;

namespace VidyaMitra.Application.Interfaces;

public interface ICourseRepository : IGenericRepository<Course>
{
    Task<IEnumerable<Course>> GetCoursesWithProfessorsAsync();
}
