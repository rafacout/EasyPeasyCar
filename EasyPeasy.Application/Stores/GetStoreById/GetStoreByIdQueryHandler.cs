using AutoMapper;
using EasyPeasy.Application.DTOs;
using EasyPeasy.Application.Stores.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Stores.GetStoreById;

public class GetStoreByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetStoreByIdQuery, ResultViewModel<StoreViewModel>>
{
    public async Task<ResultViewModel<StoreViewModel>> Handle(GetStoreByIdQuery request, CancellationToken cancellationToken)
    {
        var store = await unitOfWork.Stores.GetByIdAsync(request.Id);
        
        if (store == null)
        {
            return ResultViewModel<StoreViewModel>.Failure($"Store '{request.Id}' not exist.");
        }

        var storeDto = mapper.Map<StoreViewModel>(store);
        
        return ResultViewModel<StoreViewModel>.Success(storeDto);
    }
}