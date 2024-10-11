using AutoMapper;
using EasyPeasy.Application.DTOs;
using EasyPeasy.Application.Vehicles.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Vehicles.GetAllVehicles;

public class GetAllVehiclesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetAllVehiclesQuery, ResultViewModel<List<VehicleViewModel>>>
{
    public async Task<ResultViewModel<List<VehicleViewModel>>> Handle(GetAllVehiclesQuery request, CancellationToken cancellationToken)
    {
        var vehicles = await unitOfWork.Vehicles.GetAllAsync();

        var vehicleDtos = mapper.Map<List<VehicleViewModel>>(vehicles);
        
        return ResultViewModel<List<VehicleViewModel>>.Success(vehicleDtos);
    }
}