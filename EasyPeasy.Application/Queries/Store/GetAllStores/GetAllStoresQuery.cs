using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Queries.Store.GetAllStores;

public class GetAllStoresQuery : IRequest<ResultDto<List<StoreDto>>>
{
}