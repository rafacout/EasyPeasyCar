using EasyPeasy.Application.DTOs;
using EasyPeasy.Application.Rents.DTOs;
using MediatR;

namespace EasyPeasy.Application.Rents.GetRentById;

public class GetRentByIdQuery(Guid id) : IRequest<ResultViewModel<RentViewModel>>
{
    public Guid Id { get; set; } = id;
}