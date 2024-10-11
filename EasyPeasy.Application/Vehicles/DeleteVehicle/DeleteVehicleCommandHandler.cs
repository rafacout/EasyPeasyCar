using EasyPeasy.Application.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Vehicles.DeleteVehicle;

public class DeleteVehicleCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteVehicleCommand, ResultViewModel<Guid>>
{
    public async Task<ResultViewModel<Guid>> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = await unitOfWork.Vehicles.GetByIdAsync(request.Id);

        if (vehicle == null)
        {
            return ResultViewModel<Guid>.Failure("Vehicle not found");
        }

        await unitOfWork.Vehicles.DeleteAsync(request.Id);
        await unitOfWork.CompleteAsync();

        return ResultViewModel<Guid>.Success(request.Id, "Vehicle deleted successfully");
    }
}