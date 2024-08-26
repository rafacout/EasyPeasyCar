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
        return await _dbContext.Manufacturers.FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Guid> CreateAsync(Manufacturer manufacturer)
    {
        await _dbContext.Manufacturers.AddAsync(manufacturer);
        return manufacturer.Id;
    }
    
    public async Task UpdateAsync(Manufacturer manufacturer)
    {
        _dbContext.Manufacturers.Update(manufacturer);
    }
    
    public async Task DeleteAsync(Guid id)
    {
        var manufacturer = await _dbContext.Manufacturers.FirstOrDefaultAsync(s => s.Id == id);

        if (manufacturer is not null) { 
            _dbContext.Manufacturers.Remove(manufacturer);
        }
    }
}