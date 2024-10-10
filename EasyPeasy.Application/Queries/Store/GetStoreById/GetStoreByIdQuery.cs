using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Queries.Store.GetStoreById;

public class GetStoreByIdQuery(Guid id) : IRequest<ResultDto<StoreDto>>
{
    public Guid Id { get; set; } = id;
}