using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Queries.Category.GetCategoryById;

public class GetCategoryByIdQuery(Guid id) : IRequest<ResultDto<CategoryDto>>
{
    public Guid Id { get; set; } = id;
}