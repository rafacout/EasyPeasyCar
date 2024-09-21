using EasyPeasy.Domain.Repositories;
using EasyPeasy.Infrastructure.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace EasyPeasy.Infrastructure.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly EasyPeasyDbContext _dbContext;
    private IDbContextTransaction _transaction;

    public UnitOfWork(EasyPeasyDbContext dbContext, IManufacturerRepository manufacturers, IRentRepository rents, IStoreRepository stores, IUserRepository users, IVehicleRepository vehicles, ICategoryRepository categories)
    {
        _dbContext = dbContext;
        Manufacturers = manufacturers;
        Rents = rents;
        Stores = stores;
        Users = users;
        Vehicles = vehicles;
        Categories = categories;
    }

    public ICategoryRepository Categories { get; }
    public IManufacturerRepository Manufacturers { get; }
    public IRentRepository Rents { get; }
    public IStoreRepository Stores { get; }
    public IUserRepository Users { get; }
    public IVehicleRepository Vehicles { get; }
    
    // To use the transaction you need to first call the BeginTransactionAsync() method, then
    // Do the operation with objects (add/update/delete) and call CompleteAsync(), and finally
    // Call the CommitAsync() to commit all changes
    public async Task BeginTransactionAsync()
    {
        _transaction = await _dbContext.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        try
        {
            await _transaction.CommitAsync();
        }
        catch (Exception)
        {
            await _transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<int> CompleteAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}