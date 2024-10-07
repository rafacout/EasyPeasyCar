using AutoMapper;
using EasyPeasy.Application.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Queries.Store.GetStoreById;

public class GetStoreByIdQueryHandler : IRequestHandler<GetStoreByIdQuery, StoreDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetStoreByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<StoreDto> Handle(GetStoreByIdQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        var store = await _unitOfWork.Stores.GetByIdAsync(request.Id);
        
        return _mapper.Map<StoreDto>(store);
    }
}