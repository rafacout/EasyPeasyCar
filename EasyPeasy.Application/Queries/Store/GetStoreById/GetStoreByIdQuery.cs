using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Queries.Store.GetStoreById;

public class GetStoreByIdQuery : IRequest<StoreDto>
{
    public GetStoreByIdQuery(Guid id)
    {
        Id = id;
    }
    
    public Guid Id { get; set; }
}