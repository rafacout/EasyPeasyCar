﻿using EasyPeasy.Domain.Entities;

namespace EasyPeasy.Domain.Repositories;

public interface ICategoryRepository : IBaseRepository<Category>
{
    Task<List<Category>> GetAllAsync();
}