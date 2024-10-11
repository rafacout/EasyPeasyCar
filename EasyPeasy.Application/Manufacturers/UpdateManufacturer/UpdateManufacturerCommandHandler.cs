using EasyPeasy.Application.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Manufacturers.UpdateManufacturer;

public class UpdateManufacturerCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateManufacturerCommand, ResultDto<Guid>>
{
    public async Task<ResultDto<Guid>> Handle(UpdateManufacturerCommand request, CancellationToken cancellationToken)
    {
        var manufacturer = await unitOfWork.Manufacturers.GetByIdAsync(request.Id);

        if (manufacturer == null)
        {
            return ResultDto<Guid>.Failure("Manufacturer not found");
        }

        manufacturer.Update(request.Name, request.Country);
        unitOfWork.Manufacturers.UpdateAsync(manufacturer);
        await unitOfWork.CompleteAsync();

        return ResultDto<Guid>.Success(request.Id, "Manufacturer updated successfully");
    }
}