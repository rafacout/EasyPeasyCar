using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Commands.Manufacturer.CreateManufacturer;

public class CreateManufacturerCommandHandler : IRequestHandler<CreateManufacturerCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateManufacturerCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateManufacturerCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var entity = new Domain.Entities.Manufacturer(request.Name, request.Country);
        var id = await _unitOfWork.Manufacturers.CreateAsync(entity);
        await _unitOfWork.CompleteAsync();
        return id;
    }
}