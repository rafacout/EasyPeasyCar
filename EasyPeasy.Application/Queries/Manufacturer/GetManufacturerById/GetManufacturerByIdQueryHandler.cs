using AutoMapper;
using EasyPeasy.Application.DTOs;
using EasyPeasy.Application.Queries.Category.GetCategoryById;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Queries.Manufacturer.GetManufacturerById;

public class GetManufacturerByIdQueryHandler : IRequestHandler<GetManufacturerByIdQuery, ManufacturerDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetManufacturerByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ManufacturerDto> Handle(GetManufacturerByIdQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        var manufacturer = await _unitOfWork.Manufacturers.GetByIdAsync(request.Id);
        
        return _mapper.Map<ManufacturerDto>(manufacturer);
    }
}