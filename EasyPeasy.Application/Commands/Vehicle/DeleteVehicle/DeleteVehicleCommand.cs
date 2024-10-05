using MediatR;

namespace EasyPeasy.Application.Commands.Vehicle.DeleteVehicle;

public class DeleteVehicleCommand : IRequest<Unit>
{
    public DeleteVehicleCommand(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; set; }
}