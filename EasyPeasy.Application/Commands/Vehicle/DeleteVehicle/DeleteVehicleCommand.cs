using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Commands.Vehicle.DeleteVehicle;

public class DeleteVehicleCommand(Guid id) : IRequest<ResultDto<Guid>>
{
    public Guid Id { get; set; } = id;
}