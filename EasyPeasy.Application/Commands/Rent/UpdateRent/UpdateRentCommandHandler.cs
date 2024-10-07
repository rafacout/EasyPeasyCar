using EasyPeasy.Domain.Enum;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Commands.Rent.UpdateRent;

public class UpdateRentCommandHandler : IRequestHandler<UpdateRentCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateRentCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var rent = await _unitOfWork.Rents.GetByIdAsync(request.Id);

        if (rent != null)
        {
            rent.Update(request.UserId, request.StorePickUpId, request.StoreDropOffId, request.VehicleId,
                request.CategoryId, (StatusRent)Enum.Parse(typeof(StatusRent), request.Status), request.StartDate,
                request.ExpectedDate, request.ReturnedDate, request.Total);
            await _unitOfWork.Rents.UpdateAsync(rent);
            await _unitOfWork.CompleteAsync();
        }

        return Unit.Value;
    }
}