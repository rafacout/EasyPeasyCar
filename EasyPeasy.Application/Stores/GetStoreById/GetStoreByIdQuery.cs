using EasyPeasy.Application.DTOs;
using EasyPeasy.Application.Stores.DTOs;
using MediatR;

namespace EasyPeasy.Application.Stores.GetStoreById;

public class GetStoreByIdQuery(Guid id) : IRequest<ResultDto<StoreDto>>
{
    public Guid Id { get; set; } = id;
}