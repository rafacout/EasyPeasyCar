using EasyPeasy.Domain.Entities;
using EasyPeasy.Domain.Repositories;
using EasyPeasy.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EasyPeasy.Infrastructure.Persistence.Repositories;

public class StoreRepository : IStoreRepository
{
    private readonly EasyPeasyDbContext _dbContext;

    public StoreRepository(EasyPeasyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Store?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Stores.FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Guid> CreateAsync(Store entity)
    {
        await _dbContext.Stores.AddAsync(entity);
        return entity.Id;
    }
    
    public async Task UpdateAsync(Store entity)
    {
        _dbContext.Stores.Update(entity);
    }
    
    public async Task DeleteAsync(Guid id)
    {
        var entity = await _dbContext.Stores.FirstOrDefaultAsync(s => s.Id == id);

        if (entity is not null) { 
            _dbContext.Stores.Remove(entity);
        }
    }

    public async Task<List<Store>> GetAllAsync()
    {
        return await _dbContext.Stores.ToListAsync();
    }
}