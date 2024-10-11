using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Categories.CreateCategory;

public class CreateCategoryCommand : IRequest<ResultViewModel<Guid>>
{
    public string Name { get; set; }
}