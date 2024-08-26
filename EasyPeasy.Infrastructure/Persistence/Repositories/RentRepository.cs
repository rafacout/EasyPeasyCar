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

    public async Task<Guid> CreateAsync(Rent rent)
    {
        await _dbContext.Rents.AddAsync(rent);
        return rent.Id;
    }
    
    public async Task UpdateAsync(Rent rent)
    {
        _dbContext.Rents.Update(rent);
    }
    
    public async Task DeleteAsync(Guid id)
    {
        var rent = await _dbContext.Rents.FirstOrDefaultAsync(s => s.Id == id);

        if (rent is not null) { 
            _dbContext.Rents.Remove(rent);
        }
    }
    
}