using AutoMapper;
using EasyPeasy.Application.Categories.DTOs;
using EasyPeasy.Application.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Categories.GetCategoryById;

public class GetCategoryByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetCategoryByIdQuery, ResultDto<CategoryDto>>
{
    public async Task<ResultDto<CategoryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await unitOfWork.Categories.GetByIdAsync(request.Id);
        
        if (category == null)
        {
            return ResultDto<CategoryDto>.Failure($"Category '{request.Id}' not exist.");
        }
        
        var categoryDto = mapper.Map<CategoryDto>(category);
        
        return ResultDto<CategoryDto>.Success(categoryDto);
    }
}