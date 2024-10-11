using EasyPeasy.Application.DTOs;
using EasyPeasy.Domain.Enum;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Vehicles.UpdateVehicle;

public class UpdateVehicleCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateVehicleCommand, ResultViewModel<Guid>>
{
    public async Task<ResultViewModel<Guid>> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = await unitOfWork.Vehicles.GetByIdAsync(request.Id);

        if (vehicle == null)
        {
            return ResultViewModel<Guid>.Failure("Vehicle not found");
        }

        vehicle.Update(request.DocumentId, request.Name, request.ModelId, request.DailyRate, request.Mileage,
            request.LicensePlate, request.Color,
            (StatusVehicle)Enum.Parse(typeof(StatusVehicle), request.StatusVehicle));

        unitOfWork.Vehicles.UpdateAsync(vehicle);
        await unitOfWork.CompleteAsync();

        return ResultViewModel<Guid>.Success(request.Id, "Vehicle updated successfully");
    }
}