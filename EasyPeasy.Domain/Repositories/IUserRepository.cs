using EasyPeasy.Domain.Entities;

namespace EasyPeasy.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<List<User>> GetAllAsync();
    Task<User?> GetByEmailAndPasswordAsync(string email, string hashPassword);
}