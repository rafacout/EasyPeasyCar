using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Queries.Rent.GetRentById;

public class GetRentByIdQuery(Guid id) : IRequest<ResultDto<RentDto>>
{
    public Guid Id { get; set; } = id;
}