using MediatR;

namespace EasyPeasy.Application.Commands.Model.CreateModel;

public class CreateModelCommandHandler : IRequestHandler<CreateModelCommand, Guid>
{
    public Task<Guid> Handle(CreateModelCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}