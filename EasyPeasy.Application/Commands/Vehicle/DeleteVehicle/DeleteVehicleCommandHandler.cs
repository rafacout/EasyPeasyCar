using MediatR;

namespace EasyPeasy.Application.Commands.Vehicle.DeleteVehicle;

class DeleteVehicleCommandHandler : IRequestHandler<DeleteVehicleCommand, Unit>
{
    public Task<Unit> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}