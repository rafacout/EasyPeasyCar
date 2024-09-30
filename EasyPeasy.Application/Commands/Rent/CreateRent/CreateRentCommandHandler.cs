using MediatR;

namespace EasyPeasy.Application.Commands.Rent.CreateRent;

class CreateRentCommandHandler : IRequestHandler<CreateRentCommand, Guid>
{
    public Task<Guid> Handle(CreateRentCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}