using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Queries.Vehicle.GetVehicleById;

public class GetVehicleByIdQuery(Guid id) : IRequest<ResultDto<VehicleDto>>
{
    public Guid Id { get; set; } = id;
}