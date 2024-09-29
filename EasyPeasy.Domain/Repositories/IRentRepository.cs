using EasyPeasy.Domain.Entities;
using EasyPeasy.Domain.Models;

namespace EasyPeasy.Domain.Repositories;

public interface IRentRepository : IBaseRepository<Rent>
{
    Task<List<Rent>> GetAllAsync();
}