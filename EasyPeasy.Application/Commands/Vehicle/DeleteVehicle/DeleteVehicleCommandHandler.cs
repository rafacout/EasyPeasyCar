using EasyPeasy.Application.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Commands.Vehicle.DeleteVehicle;

public class DeleteVehicleCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteVehicleCommand, ResultDto<Guid>>
{
    public async Task<ResultDto<Guid>> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = await unitOfWork.Vehicles.GetByIdAsync(request.Id);

        if (vehicle == null)
        {
            return ResultDto<Guid>.Failure("Vehicle not found");
        }

        await unitOfWork.Vehicles.DeleteAsync(request.Id);
        await unitOfWork.CompleteAsync();

        return ResultDto<Guid>.Success(request.Id, "Vehicle deleted successfully");
    }
}