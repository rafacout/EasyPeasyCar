using AutoMapper;
using EasyPeasy.Application.DTOs;
using EasyPeasy.Application.Rents.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Rents.GetAllRents;

public class GetAllRentsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetAllRentsQuery, ResultDto<List<RentDto>>>
{
    public async Task<ResultDto<List<RentDto>>> Handle(GetAllRentsQuery request, CancellationToken cancellationToken)
    {
        var rents = await unitOfWork.Rents.GetAllAsync();

        var rentDtos = mapper.Map<List<RentDto>>(rents);
        
        return ResultDto<List<RentDto>>.Success(rentDtos);
    }
}