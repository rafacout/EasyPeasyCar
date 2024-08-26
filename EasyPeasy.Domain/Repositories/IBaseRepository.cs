﻿using EasyPeasy.Domain.Models;

namespace EasyPeasy.Domain.Repositories;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(Guid id);
    
    Task<PaginationResult<T>> GetAllAsync(string? query, int page = 1);
    
    Task<Guid> CreateAsync(T entity);
    
    Task UpdateAsync(T entity);
    
    Task DeleteAsync(Guid id);
}