using EasyPeasy.Domain.Enum;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Commands.Rent.CreateRent;

public class CreateRentCommandHandler : IRequestHandler<CreateRentCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateRentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateRentCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var rent = new Domain.Entities.Rent(request.UserId, request.StorePickUpId, request.StoreDropOffId,
            request.VehicleId, request.CategoryId, (StatusRent)Enum.Parse(typeof(StatusRent), request.Status),
            request.StartDate, request.ExpectedDate, request.ReturnedDate, request.Total);

        await _unitOfWork.Rents.CreateAsync(rent);
        await _unitOfWork.CommitAsync();

        return rent.Id;
    }
}