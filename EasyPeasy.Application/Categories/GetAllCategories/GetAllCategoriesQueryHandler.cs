using AutoMapper;
using EasyPeasy.Application.Categories.DTOs;
using EasyPeasy.Application.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Categories.GetAllCategories;

//TODO Avoid using List<T> in the return type of the query handler. Use IEnumerable<T> instead.
public class GetAllCategoriesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetAllCategoriesQuery, ResultDto<List<CategoryDto>>>
{
    public async Task<ResultDto<List<CategoryDto>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await unitOfWork.Categories.GetAllAsync();
        var data = mapper.Map<List<CategoryDto>>(categories);
        return ResultDto<List<CategoryDto>>.Success(data);
    }
}