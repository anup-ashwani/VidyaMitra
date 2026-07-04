using VidyaMitra.Application.Interfaces;
using VidyaMitra.Domain.Entities;
using System.Linq.Expressions;
using VidyaMitra.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace VidyaMitra.Repository.Repositories;

public class GenericRepository<T>(AppDbContext context) : IGenericRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext _context = context;
    protected readonly DbSet<T> _dbSet = context.Set<T>();

    public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

    public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

    public IEnumerable<T> Find(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate);

    public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

    public void Update(T entity) => _dbSet.Update(entity);

    public void Delete(T entity) => _dbSet.Remove(entity);
}