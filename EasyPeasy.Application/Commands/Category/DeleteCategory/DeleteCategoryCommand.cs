using MediatR;

namespace EasyPeasy.Application.Commands.Category.DeleteCategory;

public class DeleteCategoryCommand : IRequest<Unit>
{
    public DeleteCategoryCommand(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; private set; }
}