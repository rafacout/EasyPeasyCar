using AutoMapper;
using EasyPeasy.Application.DTOs;
using EasyPeasy.Application.Queries.Category.GetCategoryById;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Queries.Manufacturer.GetManufacturerById;

public class GetManufacturerByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetManufacturerByIdQuery, ResultDto<ManufacturerDto>>
{
    public async Task<ResultDto<ManufacturerDto>> Handle(GetManufacturerByIdQuery request, CancellationToken cancellationToken)
    {
        var manufacturer = await unitOfWork.Manufacturers.GetByIdAsync(request.Id);
        
        if (manufacturer == null)
        {
            return ResultDto<ManufacturerDto>.Failure($"Manufacturer '{request.Id}' not exist.");
        }

        var manufacturerDto = mapper.Map<ManufacturerDto>(manufacturer);
        
        return ResultDto<ManufacturerDto>.Success(manufacturerDto);
    }
}