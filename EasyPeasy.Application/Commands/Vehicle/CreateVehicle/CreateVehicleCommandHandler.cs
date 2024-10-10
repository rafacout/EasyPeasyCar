using EasyPeasy.Application.DTOs;
using EasyPeasy.Domain.Enum;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Commands.Vehicle.CreateVehicle;

public class CreateVehicleCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CreateVehicleCommand, ResultDto<Guid>>
{
    public async Task<ResultDto<Guid>> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = new Domain.Entities.Vehicle(request.DocumentId, request.Name, request.ModelId, request.DailyRate,
            request.Mileage, request.LicensePlate, request.Color,
            (StatusVehicle)Enum.Parse(typeof(StatusVehicle), request.StatusVehicle));

        await unitOfWork.Vehicles.CreateAsync(vehicle);
        await unitOfWork.CompleteAsync();

        return ResultDto<Guid>.Success(vehicle.Id, "Vehicle created successfully");
    }
}