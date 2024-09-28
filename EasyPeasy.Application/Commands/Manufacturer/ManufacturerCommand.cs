using MediatR;

namespace EasyPeasy.Application.Commands.Manufacturer;

public class ManufacturerCommand : IRequest<Guid>
{
    public string Name { get; private set; }
}