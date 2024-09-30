using MediatR;

namespace EasyPeasy.Application.Commands.Manufacturer.DeleteManufacturer;

public class DeleteManufacturerCommand : IRequest<Guid>
{
    public DeleteManufacturerCommand(Guid id)
    {
        Id = id;
    }
    
    public Guid Id { get; private set; }
}