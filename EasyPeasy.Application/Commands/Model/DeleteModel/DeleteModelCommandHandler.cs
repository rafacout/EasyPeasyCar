using MediatR;

namespace EasyPeasy.Application.Commands.Model.DeleteModel;

public class DeleteModelCommandHandler : IRequestHandler<DeleteModelCommand, Unit>
{
    public Task<Unit> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}