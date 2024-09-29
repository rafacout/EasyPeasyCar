using AutoMapper;
using EasyPeasy.Application.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Queries.Store.GetAllStores;

public class GetAllStoresQueryHandler : IRequestHandler<GetAllStoresQuery, List<StoreDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllStoresQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<StoreDto>> Handle(GetAllStoresQuery request, CancellationToken cancellationToken)
    {
        var stores = await _unitOfWork.Stores.GetAllAsync();
        return _mapper.Map<List<StoreDto>>(stores);
    }
}