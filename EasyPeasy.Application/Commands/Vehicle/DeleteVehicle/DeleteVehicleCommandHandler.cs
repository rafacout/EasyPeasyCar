using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Commands.Vehicle.DeleteVehicle;

public class DeleteVehicleCommandHandler : IRequestHandler<DeleteVehicleCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVehicleCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var vehicle = await _unitOfWork.Vehicles.GetByIdAsync(request.Id);
        
        if (vehicle != null)
        {
            await _unitOfWork.Vehicles.DeleteAsync(request.Id);
            await _unitOfWork.CommitAsync();
        }

        return Unit.Value;
    }
}