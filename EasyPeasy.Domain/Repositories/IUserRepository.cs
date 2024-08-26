using EasyPeasy.Domain.Entities;

namespace EasyPeasy.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetByEmailAndPasswordAsync(string email, string hashPassword);
}