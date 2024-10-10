using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Commands.Category.DeleteCategory;

public class DeleteCategoryCommand(Guid id) : IRequest<ResultDto<Guid>>
{
    public Guid Id { get; set; } = id;
}