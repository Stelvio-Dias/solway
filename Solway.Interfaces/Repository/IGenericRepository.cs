using Solway.Interfaces.Models;
using Solway.Interfaces.Specification;

namespace Solway.Interfaces.Repository;

public interface IGenericRepository<T> where T : class
{
    Task AddEntityAsync(T entity);
    void DeleteEntity(T entity);
    Task<IEnumerable<T?>> GetAllEntityAsync();
    Task<IEnumerable<T>> GetAllEntitiesWithSpecAsync(ISpecification<T> specification);
    Task<T?> GetEntityByIdAsync(string id);
    Task<T?> GetEntityWithSpecAsync(ISpecification<T> specification);
    void UpdateEntity(T entity);
    Task AddEntityRangeAsync(List<T> entities);
}