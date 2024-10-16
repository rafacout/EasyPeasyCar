﻿using AutoMapper;
using EasyPeasy.Application.Categories.DTOs;
using EasyPeasy.Application.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Categories.GetCategoryById;

public class GetCategoryByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetCategoryByIdQuery, ResultViewModel<CategoryViewModel>>
{
    public async Task<ResultViewModel<CategoryViewModel>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await unitOfWork.Categories.GetByIdAsync(request.Id);
        
        if (category == null)
        {
            return ResultViewModel<CategoryViewModel>.Failure($"Category '{request.Id}' not exist.");
        }
        
        var categoryDto = mapper.Map<CategoryViewModel>(category);
        
        return ResultViewModel<CategoryViewModel>.Success(categoryDto);
    }
}