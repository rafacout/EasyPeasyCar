using AutoMapper;
using EasyPeasy.Application.DTOs;
using EasyPeasy.Application.Vehicles.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Vehicles.GetVehicleById;

public class GetVehicleByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetVehicleByIdQuery, ResultDto<VehicleDto>>
{
    public async Task<ResultDto<VehicleDto>> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
    {
        var vehicle = await unitOfWork.Vehicles.GetByIdAsync(request.Id);
        
        if (vehicle == null)
        {
            return ResultDto<VehicleDto>.Failure($"Vehicle '{request.Id}' not exist.");
        }

        var vehicleDto = mapper.Map<VehicleDto>(vehicle);
        
        return ResultDto<VehicleDto>.Success(vehicleDto);
    }
}