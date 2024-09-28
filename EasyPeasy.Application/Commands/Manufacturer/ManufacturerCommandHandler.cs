using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Commands.Manufacturer;

public class ManufacturerCommandHandler : IRequestHandler<ManufacturerCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public ManufacturerCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(ManufacturerCommand request, CancellationToken cancellationToken)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));

        var entity = new Domain.Entities.Category(request.Name);
        var id = await _unitOfWork.Categories.CreateAsync(entity);
        await _unitOfWork.CompleteAsync();
        return id;
    }
}