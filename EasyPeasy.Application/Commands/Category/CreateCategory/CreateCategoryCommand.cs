using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Commands.Category.CreateCategory;

public class CreateCategoryCommand : IRequest<ResultDto<Guid>>
{
    public string Name { get; set; }
}