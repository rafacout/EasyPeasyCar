using MediatR;

namespace EasyPeasy.Application.Commands.Vehicle.UpdateVehicle;

class UpdateVehicleCommandHandler : IRequestHandler<UpdateVehicleCommand, Unit>
{
    public Task<Unit> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}