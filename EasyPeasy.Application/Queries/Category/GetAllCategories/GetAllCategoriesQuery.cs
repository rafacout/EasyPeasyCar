using MediatR;

namespace EasyPeasy.Application.Queries.Category.GetAllCategories;

public class GetAllCategoriesQuery : IRequest<IEnumerable<Domain.Entities.Category>>
{
}