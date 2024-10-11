using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Categories.CreateCategory;

public class CreateCategoryCommand : IRequest<ResultDto<Guid>>
{
    public string Name { get; set; }
}