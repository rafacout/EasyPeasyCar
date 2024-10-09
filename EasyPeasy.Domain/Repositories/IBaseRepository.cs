using EasyPeasy.Domain.Models;

namespace EasyPeasy.Domain.Repositories;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(Guid id);
    
    Task<Guid> CreateAsync(T entity);
    
    void UpdateAsync(T entity);
    
    Task DeleteAsync(Guid id);
}