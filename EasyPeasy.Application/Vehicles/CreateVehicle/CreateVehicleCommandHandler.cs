using EasyPeasy.Application.DTOs;
using EasyPeasy.Domain.Enum;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Vehicles.CreateVehicle;

public class CreateVehicleCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CreateVehicleCommand, ResultViewModel<Guid>>
{
    public async Task<ResultViewModel<Guid>> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = new Domain.Entities.Vehicle(request.DocumentId, request.Name, request.ModelId, request.DailyRate,
            request.Mileage, request.LicensePlate, request.Color,
            (StatusVehicle)Enum.Parse(typeof(StatusVehicle), request.StatusVehicle));

        await unitOfWork.Vehicles.CreateAsync(vehicle);
        await unitOfWork.CompleteAsync();

        return ResultViewModel<Guid>.Success(vehicle.Id, "Vehicle created successfully");
    }
}