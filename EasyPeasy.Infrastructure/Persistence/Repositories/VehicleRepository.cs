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

    public async Task<Guid> CreateAsync(Vehicle vehicle)
    {
        await _dbContext.Vehicles.AddAsync(vehicle);
        return vehicle.Id;
    }
    
    public async Task UpdateAsync(Vehicle vehicle)
    {
        _dbContext.Vehicles.Update(vehicle);
    }
    
    public async Task DeleteAsync(Guid id)
    {
        var vehicle = await _dbContext.Vehicles.FirstOrDefaultAsync(s => s.Id == id);

        if (vehicle is not null) { 
            _dbContext.Vehicles.Remove(vehicle);
        }
    }
}