using MediatR;

namespace EasyPeasy.Application.Commands.Model.UpdateModel;

public class UpdateModelCommandHandler : IRequestHandler<UpdateModelCommand, Unit>
{
    public Task<Unit> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}