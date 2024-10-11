using EasyPeasy.Application.DTOs;
using EasyPeasy.Domain.Enum;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Rents.CreateRent;

public class CreateRentCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateRentCommand, ResultViewModel<Guid>>
{
    public async Task<ResultViewModel<Guid>> Handle(CreateRentCommand request, CancellationToken cancellationToken)
    {
        var rent = new Domain.Entities.Rent(request.UserId, request.StorePickUpId, request.StoreDropOffId,
            request.VehicleId, request.CategoryId, (StatusRent)Enum.Parse(typeof(StatusRent), request.Status),
            request.StartDate, request.ExpectedDate, request.ReturnedDate, request.Total);

        await unitOfWork.Rents.CreateAsync(rent);
        await unitOfWork.CompleteAsync();

        return ResultViewModel<Guid>.Success(rent.Id, "Rent created successfully");
    }
}