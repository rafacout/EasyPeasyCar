using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Queries.Rent.GetAllRents;

public class GetAllRentsQuery : IRequest<List<RentDto>>
{
}