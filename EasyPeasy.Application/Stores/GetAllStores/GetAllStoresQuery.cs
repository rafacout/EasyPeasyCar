using EasyPeasy.Application.DTOs;
using EasyPeasy.Application.Stores.DTOs;
using MediatR;

namespace EasyPeasy.Application.Stores.GetAllStores;

public class GetAllStoresQuery : IRequest<ResultViewModel<List<StoreViewModel>>>
{
}