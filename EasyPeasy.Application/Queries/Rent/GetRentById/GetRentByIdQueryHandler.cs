using AutoMapper;
using EasyPeasy.Application.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Queries.Rent.GetRentById;

public class GetRentByIdQueryHandler : IRequestHandler<GetRentByIdQuery, RentDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetRentByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<RentDto> Handle(GetRentByIdQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        var rent = await _unitOfWork.Rents.GetByIdAsync(request.Id);
        
        return _mapper.Map<RentDto>(rent);
    }
}