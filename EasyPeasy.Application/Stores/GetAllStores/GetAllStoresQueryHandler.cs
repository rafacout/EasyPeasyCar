using AutoMapper;
using EasyPeasy.Application.DTOs;
using EasyPeasy.Application.Stores.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Stores.GetAllStores;

public class GetAllStoresQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetAllStoresQuery, ResultViewModel<List<StoreViewModel>>>
{
    public async Task<ResultViewModel<List<StoreViewModel>>> Handle(GetAllStoresQuery request, CancellationToken cancellationToken)
    {
        var stores = await unitOfWork.Stores.GetAllAsync();

        var storeDtos = mapper.Map<List<StoreViewModel>>(stores);
        
        return ResultViewModel<List<StoreViewModel>>.Success(storeDtos);
    }
}