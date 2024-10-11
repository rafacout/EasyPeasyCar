using EasyPeasy.Application.Categories.DTOs;
using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Categories.GetAllCategories;

public class GetAllCategoriesQuery : IRequest<ResultDto<List<CategoryDto>>>
{
}