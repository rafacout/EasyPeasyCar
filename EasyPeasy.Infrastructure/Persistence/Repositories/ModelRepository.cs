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

    public async Task<Guid> CreateAsync(Model model)
    {
        await _dbContext.Models.AddAsync(model);
        return model.Id;
    }
    
    public async Task UpdateAsync(Model model)
    {
        _dbContext.Models.Update(model);
    }
    
    public async Task DeleteAsync(Guid id)
    {
        var model = await _dbContext.Models.FirstOrDefaultAsync(s => s.Id == id);

        if (model is not null) { 
            _dbContext.Models.Remove(model);
        }
    }
    
}