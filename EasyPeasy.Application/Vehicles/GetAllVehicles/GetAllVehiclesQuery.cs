using EasyPeasy.Application.DTOs;
using EasyPeasy.Application.Vehicles.DTOs;
using MediatR;

namespace EasyPeasy.Application.Vehicles.GetAllVehicles;

public class GetAllVehiclesQuery : IRequest<ResultViewModel<List<VehicleViewModel>>>
{
}