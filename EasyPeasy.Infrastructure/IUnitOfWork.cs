using EasyPeasy.Domain.Repositories;

namespace EasyPeasy.Infrastructure;

public interface IUnitOfWork
{
    IManufacturerRepository Manufacturers { get; }
    IRentRepository Rents { get; }
    IStoreRepository Stores { get; }
    IUserRepository Users { get; }
    IVehicleRepository Vehicles { get; }
    
    
    Task BeginTransactionAsync();
    Task CommitAsync();
    Task<int> CompleteAsync();
}