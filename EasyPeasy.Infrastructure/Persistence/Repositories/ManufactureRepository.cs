using EasyPeasy.Domain.Entities;
using EasyPeasy.Domain.Models;
using EasyPeasy.Domain.Repositories;
using EasyPeasy.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EasyPeasy.Infrastructure.Persistence.Repositories;

public class ManufactureRepository : IManufacturerRepository
{
    private readonly EasyPeasyDbContext _dbContext;

    public ManufactureRepository(EasyPeasyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Manufacturer?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Manufacturers.SingleOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Guid> CreateAsync(Manufacturer entity)
    {
        await _dbContext.Manufacturers.AddAsync(entity);
        return entity.Id;
    }
    
    public void UpdateAsync(Manufacturer entity)
    {
        _dbContext.Manufacturers.Update(entity);
    }
    
    public async Task DeleteAsync(Guid id)
    {
        var entity = await _dbContext.Manufacturers.SingleOrDefaultAsync(s => s.Id == id);

        if (entity is not null) { 
            _dbContext.Manufacturers.Remove(entity);
        }
    }

    public async Task<List<Manufacturer>> GetAllAsync()
    {
        return await _dbContext.Manufacturers.ToListAsync();
    }
}