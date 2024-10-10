using EasyPeasy.Application.DTOs;
using EasyPeasy.Domain.Enum;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Commands.Rent.UpdateRent;

public class UpdateRentCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateRentCommand, ResultDto<Guid>>
{
    public async Task<ResultDto<Guid>> Handle(UpdateRentCommand request, CancellationToken cancellationToken)
    {
        var rent = await unitOfWork.Rents.GetByIdAsync(request.Id);

        if (rent == null)
        {
            return ResultDto<Guid>.Failure("Rent not found");
        }

        rent.Update(request.UserId, request.StorePickUpId, request.StoreDropOffId, request.VehicleId,
            request.CategoryId, (StatusRent)Enum.Parse(typeof(StatusRent), request.Status), request.StartDate,
            request.ExpectedDate, request.ReturnedDate, request.Total);
        unitOfWork.Rents.UpdateAsync(rent);
        await unitOfWork.CompleteAsync();

        return ResultDto<Guid>.Success(request.Id, "Rent updated successfully");
    }
}