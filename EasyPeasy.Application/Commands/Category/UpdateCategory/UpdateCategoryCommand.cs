using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Commands.Category.UpdateCategory;

public class UpdateCategoryCommand : IRequest<ResultDto<Guid>>
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
}