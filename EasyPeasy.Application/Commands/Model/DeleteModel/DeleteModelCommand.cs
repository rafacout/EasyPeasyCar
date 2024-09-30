using MediatR;

namespace EasyPeasy.Application.Commands.Model.DeleteModel;

public class DeleteModelCommand : IRequest<Unit>
{
    public Guid Id { get; set; }

    public DeleteModelCommand(Guid id)
    {
        Id = id;
    }
}