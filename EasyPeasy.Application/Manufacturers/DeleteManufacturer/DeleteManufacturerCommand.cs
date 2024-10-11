using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Manufacturers.DeleteManufacturer;

public class DeleteManufacturerCommand(Guid id) : IRequest<ResultViewModel<Guid>>
{
    public Guid Id { get; set; } = id;
}