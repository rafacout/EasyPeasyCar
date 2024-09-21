using EasyPeasy.Domain.Entities;
using EasyPeasy.Domain.Repositories;
using EasyPeasy.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EasyPeasy.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly EasyPeasyDbContext _dbContext;

    public UserRepository(EasyPeasyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Guid> CreateAsync(User entity)
    {
        await _dbContext.Users.AddAsync(entity);
        return entity.Id;
    }
    
    public async Task UpdateAsync(User entity)
    {
        _dbContext.Users.Update(entity);
    }
    
    public async Task DeleteAsync(Guid id)
    {
        var entity = await _dbContext.Users.FirstOrDefaultAsync(s => s.Id == id);

        if (entity is not null) { 
            _dbContext.Users.Remove(entity);
        }
    }

    public Task<User?> GetByEmailAndPasswordAsync(string email, string hashPassword)
    {
        throw new NotImplementedException();
    }
}