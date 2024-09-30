using MediatR;

namespace EasyPeasy.Application.Commands.Vehicle.CreateVehicle;

class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, Guid>
{
    public Task<Guid> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}