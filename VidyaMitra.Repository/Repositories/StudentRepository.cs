using VidyaMitra.Application.Interfaces;
using VidyaMitra.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using VidyaMitra.Repository.Data;

namespace VidyaMitra.Repository.Repositories;

public class StudentRepository(AppDbContext context) : GenericRepository<Student>(context), IStudentRepository
{
    public async Task<Student?> GetStudentWithEnrollmentsAsync(int studentId)
    {
        return await _context.Set<Student>()
            .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
            .FirstOrDefaultAsync(s => s.Id == studentId);
    }

    public async Task<IEnumerable<Student>> GetStudentsByDepartmentAsync(int departmentId)
    {
        return await _context.Set<Student>()
            .Where(s => s.DepartmentId == departmentId)
            .ToListAsync();
    }
}
