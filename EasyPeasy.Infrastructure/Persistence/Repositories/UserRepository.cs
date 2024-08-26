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

    public async Task<Guid> CreateAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
        return user.Id;
    }
    
    public async Task UpdateAsync(User user)
    {
        _dbContext.Users.Update(user);
    }
    
    public async Task DeleteAsync(Guid id)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(s => s.Id == id);

        if (user is not null) { 
            _dbContext.Users.Remove(user);
        }
    }

    public Task<User?> GetByEmailAndPasswordAsync(string email, string hashPassword)
    {
        throw new NotImplementedException();
    }
}