using MediatR;

namespace EasyPeasy.Application.Commands.Category.UpdateCategory;

public class UpdateCategoryCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
}