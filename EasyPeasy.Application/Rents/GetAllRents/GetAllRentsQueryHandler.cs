using AutoMapper;
using EasyPeasy.Application.DTOs;
using EasyPeasy.Application.Rents.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Rents.GetAllRents;

public class GetAllRentsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetAllRentsQuery, ResultViewModel<List<RentViewModel>>>
{
    public async Task<ResultViewModel<List<RentViewModel>>> Handle(GetAllRentsQuery request, CancellationToken cancellationToken)
    {
        var rents = await unitOfWork.Rents.GetAllAsync();

        var rentDtos = mapper.Map<List<RentViewModel>>(rents);
        
        return ResultViewModel<List<RentViewModel>>.Success(rentDtos);
    }
}