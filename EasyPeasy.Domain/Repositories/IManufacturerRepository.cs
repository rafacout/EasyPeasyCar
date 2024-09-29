using EasyPeasy.Domain.Entities;
using EasyPeasy.Domain.Models;

namespace EasyPeasy.Domain.Repositories;

public interface IManufacturerRepository : IBaseRepository<Manufacturer>
{
    Task<List<Manufacturer>> GetAllAsync();
}