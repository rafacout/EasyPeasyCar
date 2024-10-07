using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Queries.Manufacturer.GetManufacturerById;

public class GetManufacturerByIdQuery : IRequest<ManufacturerDto>
{
    public GetManufacturerByIdQuery(Guid id)
    {
        Id = id;
    }
    
    public Guid Id { get; set; }
}