using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Queries.Manufacturer.GetManufacturerById;

public class GetManufacturerByIdQuery(Guid id) : IRequest<ResultDto<ManufacturerDto>>
{
    public Guid Id { get; set; } = id;
}