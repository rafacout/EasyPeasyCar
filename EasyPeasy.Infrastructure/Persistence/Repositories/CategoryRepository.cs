using EasyPeasy.Domain.Entities;
using EasyPeasy.Domain.Repositories;
using EasyPeasy.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EasyPeasy.Infrastructure.Persistence.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly EasyPeasyDbContext _dbContext;

    public CategoryRepository(EasyPeasyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Category?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Categories.FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Guid> CreateAsync(Category entity)
    {
        await _dbContext.Categories.AddAsync(entity);
        return entity.Id;
    }

    public async Task UpdateAsync(Category entity)
    {
        _dbContext.Categories.Update(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _dbContext.Categories.FirstOrDefaultAsync(s => s.Id == id);

        if (entity is not null) { 
            _dbContext.Categories.Remove(entity);
        }
    }
}