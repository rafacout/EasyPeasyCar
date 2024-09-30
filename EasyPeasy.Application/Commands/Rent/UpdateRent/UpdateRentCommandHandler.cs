using MediatR;

namespace EasyPeasy.Application.Commands.Rent.UpdateRent;

class UpdateRentCommandHandler : IRequestHandler<UpdateRentCommand, Unit>
{
    public Task<Unit> Handle(UpdateRentCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}