using MediatR;

namespace EasyPeasy.Application.Queries.Category.GetAllCategories;

public class GetAllCategoriesQuery : IRequest<List<Domain.Entities.Category>>
{
}