using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Vehicles.DeleteVehicle;

public class DeleteVehicleCommand(Guid id) : IRequest<ResultViewModel<Guid>>
{
    public Guid Id { get; set; } = id;
}