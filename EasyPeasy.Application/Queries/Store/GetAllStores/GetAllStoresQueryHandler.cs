using AutoMapper;
using EasyPeasy.Application.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Queries.Store.GetAllStores;

public class GetAllStoresQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetAllStoresQuery, ResultDto<List<StoreDto>>>
{
    public async Task<ResultDto<List<StoreDto>>> Handle(GetAllStoresQuery request, CancellationToken cancellationToken)
    {
        var stores = await unitOfWork.Stores.GetAllAsync();

        var storeDtos = mapper.Map<List<StoreDto>>(stores);
        
        return ResultDto<List<StoreDto>>.Success(storeDtos);
    }
}