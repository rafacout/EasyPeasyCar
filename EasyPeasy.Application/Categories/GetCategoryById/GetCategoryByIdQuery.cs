﻿using EasyPeasy.Application.Categories.DTOs;
using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Categories.GetCategoryById;

public class GetCategoryByIdQuery(Guid id) : IRequest<ResultViewModel<CategoryViewModel>>
{
    public Guid Id { get; set; } = id;
}