using VidyaMitra.Domain.Entities;

namespace VidyaMitra.Application.Interfaces;

public interface IStudentRepository : IGenericRepository<Student>
{
    Task<Student?> GetStudentWithEnrollmentsAsync(int studentId);
    Task<IEnumerable<Student>> GetStudentsByDepartmentAsync(int departmentId);
}
