using EasyPeasy.Domain.Entities;
using EasyPeasy.Domain.Repositories;
using EasyPeasy.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EasyPeasy.Infrastructure.Persistence.Repositories;

public class RentRepository : IRentRepository
{
    private readonly EasyPeasyDbContext _dbContext;

    public RentRepository(EasyPeasyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Rent?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Rents.FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Guid> CreateAsync(Rent entity)
    {
        await _dbContext.Rents.AddAsync(entity);
        return entity.Id;
    }
    
    public async Task UpdateAsync(Rent entity)
    {
        _dbContext.Rents.Update(entity);
    }
    
    public async Task DeleteAsync(Guid id)
    {
        var entity = await _dbContext.Rents.FirstOrDefaultAsync(s => s.Id == id);

        if (entity is not null) { 
            _dbContext.Rents.Remove(entity);
        }
    }
    
}