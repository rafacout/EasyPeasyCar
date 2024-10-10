using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Commands.Manufacturer.CreateManufacturer;

public class CreateManufacturerCommand : IRequest<ResultDto<Guid>>
{
    public string Name { get; set; }
    
    public string Country { get; set; }
}