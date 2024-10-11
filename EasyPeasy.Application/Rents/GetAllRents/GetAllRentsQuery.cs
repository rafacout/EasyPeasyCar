using EasyPeasy.Application.DTOs;
using EasyPeasy.Application.Rents.DTOs;
using MediatR;

namespace EasyPeasy.Application.Rents.GetAllRents;

public class GetAllRentsQuery : IRequest<ResultDto<List<RentDto>>>
{
}