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

    public async Task<Guid> CreateAsync(Store store)
    {
        await _dbContext.Stores.AddAsync(store);
        return store.Id;
    }
    
    public async Task UpdateAsync(Store store)
    {
        _dbContext.Stores.Update(store);
    }
    
    public async Task DeleteAsync(Guid id)
    {
        var store = await _dbContext.Stores.FirstOrDefaultAsync(s => s.Id == id);

        if (store is not null) { 
            _dbContext.Stores.Remove(store);
        }
    }
}