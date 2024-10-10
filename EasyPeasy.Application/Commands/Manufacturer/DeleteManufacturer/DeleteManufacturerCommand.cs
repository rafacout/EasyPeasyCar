using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Commands.Manufacturer.DeleteManufacturer;

public class DeleteManufacturerCommand(Guid id) : IRequest<ResultDto<Guid>>
{
    public Guid Id { get; set; } = id;
}