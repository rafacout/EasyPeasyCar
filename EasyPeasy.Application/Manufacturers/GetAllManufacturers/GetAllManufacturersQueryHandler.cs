using AutoMapper;
using EasyPeasy.Application.DTOs;
using EasyPeasy.Application.Manufacturers.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Manufacturers.GetAllManufacturers;

public class GetAllManufacturersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetAllManufacturersQuery, ResultDto<List<ManufacturerDto>>>
{
    public async Task<ResultDto<List<ManufacturerDto>>> Handle(GetAllManufacturersQuery request, CancellationToken cancellationToken)
    {
        var manufacturers = await unitOfWork.Manufacturers.GetAllAsync();

        var manufacturerDtos = mapper.Map<List<ManufacturerDto>>(manufacturers);
        
        return ResultDto<List<ManufacturerDto>>.Success(manufacturerDtos);
    }
}