using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Manufacturers.CreateManufacturer;

public class CreateManufacturerCommand : IRequest<ResultDto<Guid>>
{
    public string Name { get; set; }
    
    public string Country { get; set; }
}