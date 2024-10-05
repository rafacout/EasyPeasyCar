using MediatR;

namespace EasyPeasy.Application.Commands.Manufacturer.UpdateManufacturer;

public class UpdateManufacturerCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    public string Country { get; set; }
}