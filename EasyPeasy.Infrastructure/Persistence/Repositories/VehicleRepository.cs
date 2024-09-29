using EasyPeasy.Domain.Entities;
using EasyPeasy.Domain.Repositories;
using EasyPeasy.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EasyPeasy.Infrastructure.Persistence.Repositories;

public class VehicleRepository : IVehicleRepository
{
    private readonly EasyPeasyDbContext _dbContext;

    public VehicleRepository(EasyPeasyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Vehicle?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Vehicles.FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Guid> CreateAsync(Vehicle entity)
    {
        await _dbContext.Vehicles.AddAsync(entity);
        return entity.Id;
    }
    
    public async Task UpdateAsync(Vehicle entity)
    {
        _dbContext.Vehicles.Update(entity);
    }
    
    public async Task DeleteAsync(Guid id)
    {
        var entity = await _dbContext.Vehicles.FirstOrDefaultAsync(s => s.Id == id);

        if (entity is not null) { 
            _dbContext.Vehicles.Remove(entity);
        }
    }

    public async Task<List<Vehicle>> GetAllAsync()
    {
        return await _dbContext.Vehicles.ToListAsync();
    }
}