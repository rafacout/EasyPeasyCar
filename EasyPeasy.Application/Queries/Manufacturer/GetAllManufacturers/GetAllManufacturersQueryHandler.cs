using AutoMapper;
using EasyPeasy.Application.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Queries.Manufacturer.GetAllManufacturers;

public class GetAllManufacturersQueryHandler : IRequestHandler<GetAllManufacturersQuery, List<ManufacturerDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllManufacturersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<ManufacturerDto>> Handle(GetAllManufacturersQuery request, CancellationToken cancellationToken)
    {
        var manufacturers = await _unitOfWork.Manufacturers.GetAllAsync();
        return _mapper.Map<List<ManufacturerDto>>(manufacturers);
    }
}