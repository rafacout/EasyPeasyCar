using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Manufacturers.UpdateManufacturer;

public class UpdateManufacturerCommand : IRequest<ResultViewModel<Guid>>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
}