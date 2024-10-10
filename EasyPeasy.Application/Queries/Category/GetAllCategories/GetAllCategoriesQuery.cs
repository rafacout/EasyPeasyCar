using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Queries.Category.GetAllCategories;

public class GetAllCategoriesQuery : IRequest<ResultDto<List<CategoryDto>>>
{
}