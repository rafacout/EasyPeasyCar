using EasyPeasy.Domain.Enum;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Commands.Vehicle.UpdateVehicle;

public class UpdateVehicleCommandHandler : IRequestHandler<UpdateVehicleCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVehicleCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var vehicle = await _unitOfWork.Vehicles.GetByIdAsync(request.Id);

        if (vehicle != null)
        {
            vehicle.Update(request.DocumentId, request.Name, request.ModelId, request.DailyRate, request.Mileage,
                request.LicensePlate, request.Color,
                (StatusVehicle)Enum.Parse(typeof(StatusVehicle), request.StatusVehicle));

            await _unitOfWork.Vehicles.UpdateAsync(vehicle);
            await _unitOfWork.CommitAsync();
        }

        return Unit.Value;
    }
}