using MediatR;

namespace EasyPeasy.Application.Commands.Category.UpdateCategory;

public class UpdateCategoryCommand : IRequest<Unit>
{
    public Guid Id { get; private set; }
    
    public string Name { get; private set; }
}