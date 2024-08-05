using Solway.DTO;
using Solway.Models;
using Solway.Interfaces.Specification;

namespace Solway.Interfaces.Services;

public interface IGenericService<Entity> where Entity : BaseEntity
{
    Task<ServerResponse> AddEntity(Entity entity);
    Task<ServerResponse> DeleteEntity(string id);
    Task<ServerResponse> GetEntities();
    Task<ServerResponse> GetEntityById(string id);
    Task<ServerResponse> UpdateEntity(Entity entity);
}