using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Queries.Vehicle.GetVehicleById;

public class GetVehicleByIdQuery : IRequest<VehicleDto>
{
    public GetVehicleByIdQuery(Guid id)
    {
        Id = id;
    }
    
    public Guid Id { get; set; }
}