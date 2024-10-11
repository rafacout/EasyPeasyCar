using EasyPeasy.Application.DTOs;
using EasyPeasy.Application.Manufacturers.DTOs;
using MediatR;

namespace EasyPeasy.Application.Manufacturers.GetManufacturerById;

public class GetManufacturerByIdQuery(Guid id) : IRequest<ResultViewModel<ManufacturerViewModel>>
{
    public Guid Id { get; set; } = id;
}