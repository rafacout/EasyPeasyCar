using EasyPeasy.Application.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Manufacturers.DeleteManufacturer;

public class DeleteManufacturerCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteManufacturerCommand, ResultViewModel<Guid>>
{
    public async Task<ResultViewModel<Guid>> Handle(DeleteManufacturerCommand request, CancellationToken cancellationToken)
    {
        var manufacturer = await unitOfWork.Manufacturers.GetByIdAsync(request.Id);

        if (manufacturer == null)
        {
            return ResultViewModel<Guid>.Failure("Manufacturer not found");
        }

        await unitOfWork.Manufacturers.DeleteAsync(request.Id);
        await unitOfWork.CompleteAsync();

        return ResultViewModel<Guid>.Success(request.Id, "Manufacturer deleted successfully");
    }
}