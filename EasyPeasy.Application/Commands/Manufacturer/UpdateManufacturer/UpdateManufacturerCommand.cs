using MediatR;

namespace EasyPeasy.Application.Commands.Manufacturer.UpdateManufacturer;

public class UpdateManufacturerCommand : IRequest<Unit>
{
    public Guid Id { get; private set; }
    
    public string Name { get; private set; }
}