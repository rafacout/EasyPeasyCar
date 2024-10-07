using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Commands.Manufacturer.UpdateManufacturer;

public class UpdateManufacturerCommandHandler : IRequestHandler<UpdateManufacturerCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateManufacturerCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateManufacturerCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        var manufacturer = await _unitOfWork.Manufacturers.GetByIdAsync(request.Id);
        
        if (manufacturer != null)
        {
            manufacturer.Update(request.Name, request.Country);
            await _unitOfWork.Manufacturers.UpdateAsync(manufacturer);
            await _unitOfWork.CompleteAsync();    
        }

        return Unit.Value;
    }
}