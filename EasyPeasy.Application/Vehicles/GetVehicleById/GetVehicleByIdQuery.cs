using EasyPeasy.Application.DTOs;
using EasyPeasy.Application.Vehicles.DTOs;
using MediatR;

namespace EasyPeasy.Application.Vehicles.GetVehicleById;

public class GetVehicleByIdQuery(Guid id) : IRequest<ResultDto<VehicleDto>>
{
    public Guid Id { get; set; } = id;
}