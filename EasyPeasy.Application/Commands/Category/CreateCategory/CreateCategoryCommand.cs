using MediatR;

namespace EasyPeasy.Application.Commands.Category.CreateCategory;

public class CreateCategoryCommand : IRequest<Guid>
{
    public string Name { get; set; }
}