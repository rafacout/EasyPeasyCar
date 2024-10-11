using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Categories.UpdateCategory;

public class UpdateCategoryCommand : IRequest<ResultViewModel<Guid>>
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
}