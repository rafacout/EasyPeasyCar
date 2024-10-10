using EasyPeasy.Application.DTOs;
using EasyPeasy.Domain.Enum;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Commands.Rent.CreateRent;

public class CreateRentCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateRentCommand, ResultDto<Guid>>
{
    public async Task<ResultDto<Guid>> Handle(CreateRentCommand request, CancellationToken cancellationToken)
    {
        var rent = new Domain.Entities.Rent(request.UserId, request.StorePickUpId, request.StoreDropOffId,
            request.VehicleId, request.CategoryId, (StatusRent)Enum.Parse(typeof(StatusRent), request.Status),
            request.StartDate, request.ExpectedDate, request.ReturnedDate, request.Total);

        await unitOfWork.Rents.CreateAsync(rent);
        await unitOfWork.CompleteAsync();

        return ResultDto<Guid>.Success(rent.Id, "Rent created successfully");
    }
}