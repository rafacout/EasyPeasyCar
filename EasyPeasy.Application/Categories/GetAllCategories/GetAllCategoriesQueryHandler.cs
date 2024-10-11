using AutoMapper;
using EasyPeasy.Application.Categories.DTOs;
using EasyPeasy.Application.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Categories.GetAllCategories;

//TODO Avoid using List<T> in the return type of the query handler. Use IEnumerable<T> instead.
public class GetAllCategoriesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetAllCategoriesQuery, ResultViewModel<List<CategoryViewModel>>>
{
    public async Task<ResultViewModel<List<CategoryViewModel>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await unitOfWork.Categories.GetAllAsync();
        var data = mapper.Map<List<CategoryViewModel>>(categories);
        return ResultViewModel<List<CategoryViewModel>>.Success(data);
    }
}