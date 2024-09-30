using MediatR;

namespace EasyPeasy.Application.Commands.Manufacturer.UpdateManufacturer;

public class UpdateManufacturerCommandHandler : IRequestHandler<UpdateManufacturerCommand, Unit>
{
    public Task<Unit> Handle(UpdateManufacturerCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}