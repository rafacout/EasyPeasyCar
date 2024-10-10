using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Queries.Vehicle.GetAllVehicles;

public class GetAllVehiclesQuery : IRequest<ResultDto<List<VehicleDto>>>
{
}