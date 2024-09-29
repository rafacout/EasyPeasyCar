using EasyPeasy.Domain.Entities;

namespace EasyPeasy.Domain.Repositories;

public interface IVehicleRepository : IBaseRepository<Vehicle>
{
    Task<List<Vehicle>> GetAllAsync();
}