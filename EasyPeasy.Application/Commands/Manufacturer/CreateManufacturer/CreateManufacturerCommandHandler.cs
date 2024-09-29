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
        if (request == null) throw new ArgumentNullException(nameof(request));

        var entity = new Domain.Entities.Category(request.Name);
        var id = await _unitOfWork.Categories.CreateAsync(entity);
        await _unitOfWork.CompleteAsync();
        return id;
    }
}