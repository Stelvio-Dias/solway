using Solway.Interfaces;
using Solway.Interfaces.Repository;
using Solway.Interfaces.Services;
using Solway.DTO;
using Solway.Models;
using Solway.DAC;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Solway.Services;

public class GenericService<Entity> : IGenericService<Entity> where Entity : BaseEntity
{
    private readonly IUniteOfWork _uniteOfWork;
    private readonly IGenericRepository<Entity> _genericRepository;
    private readonly IConfiguration? _configuration;

    public GenericService(
        IUniteOfWork uniteOfWork, 
        IGenericRepository<Entity> genericRepository
    )
    {
        _uniteOfWork = uniteOfWork;
        _genericRepository = genericRepository;
    }

    public async Task<ServerResponse> GetEntityById(string id)
    {
        Entity? entity = await _genericRepository.GetEntityByIdAsync(id);

        ServerResponse response = new(200);

        if (entity is null) response.StatusCode = 404;

        response.Objects = entity;

        return response;
    }

    public async Task<ServerResponse> GetEntities()
    {
        IEnumerable<Entity?>? entities = await _genericRepository.GetAllEntityAsync();

        ServerResponse response = new(200);

        if (entities is null) response.StatusCode = 404;

        response.Objects = entities;

        return response;
    }

    public async Task<ServerResponse> AddEntity(Entity entity)
    {
        ServerResponse response = new(200);

        entity.CreatedAt = DateTime.UtcNow;

        entity.UpdatedAt = DateTime.UtcNow;

        await _genericRepository.AddEntityAsync(entity);

        await _uniteOfWork.SaveAsync();

        return response;
    }

    public async Task<ServerResponse> UpdateEntity(Entity entity)
    {
        ServerResponse response = new(200);

        Entity? databaseEntity = await _genericRepository.GetEntityByIdAsync(entity.Id);

        if (databaseEntity is null)
        {
            response.StatusCode = 404;
            return response;
        }

        databaseEntity.CreatedAt = DateTime.UtcNow;
        databaseEntity.UpdatedAt = DateTime.UtcNow;

        DbContextOptionsBuilder<SolwayDbContext> optionsBuilder = new();
        optionsBuilder.UseSqlite(_configuration?.GetConnectionString("DefaultConnection"));

        await using (SolwayDbContext solwayDbContext = new(optionsBuilder.Options))
        {
            solwayDbContext.Entry(databaseEntity).CurrentValues.SetValues(entity);

            _genericRepository.UpdateEntity(databaseEntity);

            await _uniteOfWork.SaveAsync();
        }
        
        return response;
    }

    public async Task<ServerResponse> DeleteEntity(string id)
    {
        ServerResponse response = new(200);

        Entity? entity = await _genericRepository.GetEntityByIdAsync(id);

        if (entity is null)
        {
            response.StatusCode = 404;
            return response;
        }

        _genericRepository.DeleteEntity(entity);
        await _uniteOfWork.SaveAsync();

        return response;
    }
}