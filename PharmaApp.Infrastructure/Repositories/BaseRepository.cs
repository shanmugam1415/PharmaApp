using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using PharmaApp.Application.Repositories;
using PharmaApp.Domain.Common;
using PharmaApp.Infrastructure.Context;

namespace PharmaApp.Infrastructure.Repositories;



public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    public readonly PharmaDbContext _context;
    public readonly DbSet<T> _dbSet;

    public BaseRepository(PharmaDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity; // Returns the inserted entity with updated values
    }

    public async Task Update(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.Where(predicate).FirstOrDefaultAsync();
    }
}