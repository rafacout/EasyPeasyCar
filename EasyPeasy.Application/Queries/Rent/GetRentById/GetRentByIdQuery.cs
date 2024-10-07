using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Queries.Rent.GetRentById;

public class GetRentByIdQuery : IRequest<RentDto>
{
    public GetRentByIdQuery(Guid id)
    {
        Id = id;
    }
    
    public Guid Id { get; set; }
}