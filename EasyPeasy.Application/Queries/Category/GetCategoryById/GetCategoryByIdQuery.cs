using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Queries.Category.GetCategoryById;

public class GetCategoryByIdQuery : IRequest<CategoryDto>
{
    public GetCategoryByIdQuery(Guid id)
    {
        Id = id;
    }
    
    public Guid Id { get; set; }
}