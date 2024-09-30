using MediatR;

namespace EasyPeasy.Application.Commands.Manufacturer.DeleteManufacturer;

class DeleteManufacturerCommandHandler : IRequestHandler<DeleteManufacturerCommand, Guid>
{
    public Task<Guid> Handle(DeleteManufacturerCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}