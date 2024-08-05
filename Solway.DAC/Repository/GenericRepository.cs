using Solway.DAC.Specification;
using Solway.Interfaces.Repository;
using Solway.Interfaces.Specification;
using Solway.Models;

using Microsoft.EntityFrameworkCore;

namespace Solway.DAC.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly SolwayDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(SolwayDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    // get data by id
    public async Task<T?> GetEntityByIdAsync(string id) => await _dbSet.FindAsync(id);

    // get all data
    public async Task<IEnumerable<T?>> GetAllEntityAsync() => await _dbSet.ToListAsync();

    // get data with specification / filter
    public async Task<T?> GetEntityWithSpecAsync(ISpecification<T> specification)
    {
        return await ApplySpecification(specification).FirstOrDefaultAsync();
    }

    // Get all data with Specification / filter
    public async Task<IEnumerable<T>> GetAllEntitiesWithSpecAsync(ISpecification<T> specification)
    {
        return await ApplySpecification(specification).ToListAsync();
    }

    // Add Data
    public async Task AddEntityAsync(T entity) => await _context.AddAsync(entity);

    // Add Data Range
    public async Task AddEntityRangeAsync(List<T> entities) => await _context.AddRangeAsync(entities);

    // Update Entity
    public void UpdateEntity(T entity) => _context.Update(entity);

    // Delete Entity
    public void DeleteEntity(T entity) => _context.Remove(entity);

    // Apply the specification
    private IQueryable<T> ApplySpecification(ISpecification<T> specification)
    {
        return SpecificationEvaluator<T>.GetQuery(_dbSet.AsQueryable(), specification);
    }
}