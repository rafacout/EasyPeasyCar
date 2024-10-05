using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Commands.Manufacturer.DeleteManufacturer;

public class DeleteManufacturerCommandHandler : IRequestHandler<DeleteManufacturerCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteManufacturerCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteManufacturerCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        await _unitOfWork.Manufacturers.DeleteAsync(request.Id);
        await _unitOfWork.CompleteAsync();
        
        return Unit.Value;
    }
}