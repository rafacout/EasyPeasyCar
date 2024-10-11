using AutoMapper;
using EasyPeasy.Application.DTOs;
using EasyPeasy.Application.Vehicles.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Vehicles.GetAllVehicles;

public class GetAllVehiclesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetAllVehiclesQuery, ResultDto<List<VehicleDto>>>
{
    public async Task<ResultDto<List<VehicleDto>>> Handle(GetAllVehiclesQuery request, CancellationToken cancellationToken)
    {
        var vehicles = await unitOfWork.Vehicles.GetAllAsync();

        var vehicleDtos = mapper.Map<List<VehicleDto>>(vehicles);
        
        return ResultDto<List<VehicleDto>>.Success(vehicleDtos);
    }
}