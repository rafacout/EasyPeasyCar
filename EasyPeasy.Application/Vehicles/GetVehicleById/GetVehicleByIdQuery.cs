using EasyPeasy.Application.DTOs;
using EasyPeasy.Application.Vehicles.DTOs;
using MediatR;

namespace EasyPeasy.Application.Vehicles.GetVehicleById;

public class GetVehicleByIdQuery(Guid id) : IRequest<ResultViewModel<VehicleViewModel>>
{
    public Guid Id { get; set; } = id;
}