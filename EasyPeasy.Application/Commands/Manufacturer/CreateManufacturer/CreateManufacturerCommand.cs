using MediatR;

namespace EasyPeasy.Application.Commands.Manufacturer.CreateManufacturer;

public class CreateManufacturerCommand : IRequest<Guid>
{
    public string Name { get; private set; }
}