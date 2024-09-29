using AutoMapper;
using EasyPeasy.Application.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Queries.Rent.GetAllRents;

public class GetAllRentsQueryHandler : IRequestHandler<GetAllRentsQuery, List<RentDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllRentsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<RentDto>> Handle(GetAllRentsQuery request, CancellationToken cancellationToken)
    {
        var rents = await _unitOfWork.Rents.GetAllAsync();
        return _mapper.Map<List<RentDto>>(rents);
    }
}