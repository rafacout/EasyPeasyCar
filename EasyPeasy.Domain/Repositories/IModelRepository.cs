﻿using EasyPeasy.Domain.Entities;
using EasyPeasy.Domain.Models;

namespace EasyPeasy.Domain.Repositories;

public interface IModelRepository : IBaseRepository<Model>
{
    Task<List<Model>> GetAllAsync();
}