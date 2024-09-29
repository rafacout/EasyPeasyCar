using EasyPeasy.Domain.Repositories;

namespace EasyPeasy.Infrastructure.Persistence.Repositories;

public interface IUnitOfWork
{
    ICategoryRepository Categories { get; }
    IManufacturerRepository Manufacturers { get; }
    IRentRepository Rents { get; }
    IModelRepository Models { get; }
    IStoreRepository Stores { get; }
    IUserRepository Users { get; }
    IVehicleRepository Vehicles { get; }
    
    
    Task BeginTransactionAsync();
    Task CommitAsync();
    Task<int> CompleteAsync();
}