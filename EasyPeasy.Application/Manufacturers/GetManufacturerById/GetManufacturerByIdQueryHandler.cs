using AutoMapper;
using EasyPeasy.Application.DTOs;
using EasyPeasy.Application.Manufacturers.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Manufacturers.GetManufacturerById;

public class GetManufacturerByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetManufacturerByIdQuery, ResultViewModel<ManufacturerViewModel>>
{
    public async Task<ResultViewModel<ManufacturerViewModel>> Handle(GetManufacturerByIdQuery request, CancellationToken cancellationToken)
    {
        var manufacturer = await unitOfWork.Manufacturers.GetByIdAsync(request.Id);
        
        if (manufacturer == null)
        {
            return ResultViewModel<ManufacturerViewModel>.Failure($"Manufacturer '{request.Id}' not exist.");
        }

        var manufacturerDto = mapper.Map<ManufacturerViewModel>(manufacturer);
        
        return ResultViewModel<ManufacturerViewModel>.Success(manufacturerDto);
    }
}