using EasyPeasy.Domain.Entities;
using EasyPeasy.Domain.Repositories;
using EasyPeasy.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EasyPeasy.Infrastructure.Persistence.Repositories;

public class ModelRepository : IModelRepository
{
    private readonly EasyPeasyDbContext _dbContext;

    public ModelRepository(EasyPeasyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Model?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Models.FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Guid> CreateAsync(Model entity)
    {
        await _dbContext.Models.AddAsync(entity);
        return entity.Id;
    }
    
    public async Task UpdateAsync(Model entity)
    {
        _dbContext.Models.Update(entity);
    }
    
    public async Task DeleteAsync(Guid id)
    {
        var entity = await _dbContext.Models.FirstOrDefaultAsync(s => s.Id == id);

        if (entity is not null) { 
            _dbContext.Models.Remove(entity);
        }
    }

    public async Task<List<Model>> GetAllAsync()
    {
        return await _dbContext.Models.ToListAsync();
    }
}