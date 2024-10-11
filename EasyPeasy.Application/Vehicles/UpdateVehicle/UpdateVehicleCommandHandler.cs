using EasyPeasy.Application.DTOs;
using EasyPeasy.Domain.Enum;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Vehicles.UpdateVehicle;

public class UpdateVehicleCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateVehicleCommand, ResultDto<Guid>>
{
    public async Task<ResultDto<Guid>> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = await unitOfWork.Vehicles.GetByIdAsync(request.Id);

        if (vehicle == null)
        {
            return ResultDto<Guid>.Failure("Vehicle not found");
        }

        vehicle.Update(request.DocumentId, request.Name, request.ModelId, request.DailyRate, request.Mileage,
            request.LicensePlate, request.Color,
            (StatusVehicle)Enum.Parse(typeof(StatusVehicle), request.StatusVehicle));

        unitOfWork.Vehicles.UpdateAsync(vehicle);
        await unitOfWork.CompleteAsync();

        return ResultDto<Guid>.Success(request.Id, "Vehicle updated successfully");
    }
}