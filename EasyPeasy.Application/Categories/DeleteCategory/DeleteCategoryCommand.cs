using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Categories.DeleteCategory;

public class DeleteCategoryCommand(Guid id) : IRequest<ResultViewModel<Guid>>
{
    public Guid Id { get; set; } = id;
}