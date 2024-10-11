using AutoMapper;
using EasyPeasy.Application.DTOs;
using EasyPeasy.Application.Vehicles.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Vehicles.GetVehicleById;

public class GetVehicleByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetVehicleByIdQuery, ResultViewModel<VehicleViewModel>>
{
    public async Task<ResultViewModel<VehicleViewModel>> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
    {
        var vehicle = await unitOfWork.Vehicles.GetByIdAsync(request.Id);
        
        if (vehicle == null)
        {
            return ResultViewModel<VehicleViewModel>.Failure($"Vehicle '{request.Id}' not exist.");
        }

        var vehicleDto = mapper.Map<VehicleViewModel>(vehicle);
        
        return ResultViewModel<VehicleViewModel>.Success(vehicleDto);
    }
}