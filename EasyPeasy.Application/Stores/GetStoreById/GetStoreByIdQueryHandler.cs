using AutoMapper;
using EasyPeasy.Application.DTOs;
using EasyPeasy.Application.Stores.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Stores.GetStoreById;

public class GetStoreByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetStoreByIdQuery, ResultDto<StoreDto>>
{
    public async Task<ResultDto<StoreDto>> Handle(GetStoreByIdQuery request, CancellationToken cancellationToken)
    {
        var store = await unitOfWork.Stores.GetByIdAsync(request.Id);
        
        if (store == null)
        {
            return ResultDto<StoreDto>.Failure($"Store '{request.Id}' not exist.");
        }

        var storeDto = mapper.Map<StoreDto>(store);
        
        return ResultDto<StoreDto>.Success(storeDto);
    }
}