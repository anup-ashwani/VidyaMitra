using VidyaMitra.Application.Interfaces;
using VidyaMitra.Domain.Entities;
using System.Linq.Expressions;
using VidyaMitra.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace VidyaMitra.Repository.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public IStudentRepository Students { get; private set; }
    public ICourseRepository Courses { get; private set; }

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        Students = new StudentRepository(_context);
        Courses = new CourseRepository(_context);
    }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
}
