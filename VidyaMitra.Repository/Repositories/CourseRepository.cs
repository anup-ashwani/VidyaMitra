using VidyaMitra.Application.Interfaces;
using VidyaMitra.Domain.Entities;
using System.Linq.Expressions;
using VidyaMitra.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace VidyaMitra.Repository.Repositories;

public class CourseRepository(AppDbContext context) : GenericRepository<Course>(context), ICourseRepository
{
    public async Task<IEnumerable<Course>> GetCoursesWithProfessorsAsync()
    {
        return await _context.Set<Course>()
            .Include(c => c.Professor)
            .Include(c => c.Department)
            .ToListAsync();
    }
}
