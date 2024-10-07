using EasyPeasy.Domain.Enum;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Commands.Vehicle.CreateVehicle;

public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateVehicleCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var vehicle = new Domain.Entities.Vehicle(request.DocumentId, request.Name, request.ModelId, request.DailyRate,
            request.Mileage, request.LicensePlate, request.Color,
            (StatusVehicle)Enum.Parse(typeof(StatusVehicle), request.StatusVehicle));

        await _unitOfWork.Vehicles.CreateAsync(vehicle);
        await _unitOfWork.CompleteAsync();

        return vehicle.Id;
    }
}