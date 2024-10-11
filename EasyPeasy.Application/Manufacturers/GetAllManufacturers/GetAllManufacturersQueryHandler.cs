using AutoMapper;
using EasyPeasy.Application.DTOs;
using EasyPeasy.Application.Manufacturers.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Manufacturers.GetAllManufacturers;

public class GetAllManufacturersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetAllManufacturersQuery, ResultViewModel<List<ManufacturerViewModel>>>
{
    public async Task<ResultViewModel<List<ManufacturerViewModel>>> Handle(GetAllManufacturersQuery request, CancellationToken cancellationToken)
    {
        var manufacturers = await unitOfWork.Manufacturers.GetAllAsync();

        var manufacturerDtos = mapper.Map<List<ManufacturerViewModel>>(manufacturers);
        
        return ResultViewModel<List<ManufacturerViewModel>>.Success(manufacturerDtos);
    }
}