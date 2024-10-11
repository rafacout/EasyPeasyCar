using AutoMapper;
using EasyPeasy.Application.DTOs;
using EasyPeasy.Application.Rents.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Rents.GetRentById;

public class GetRentByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetRentByIdQuery, ResultViewModel<RentViewModel>>
{
    public async Task<ResultViewModel<RentViewModel>> Handle(GetRentByIdQuery request, CancellationToken cancellationToken)
    {
        var rent = await unitOfWork.Rents.GetByIdAsync(request.Id);
        
        if (rent == null)
        {
            return ResultViewModel<RentViewModel>.Failure($"Rent '{request.Id}' not exist.");
        }

        var rentDto = mapper.Map<RentViewModel>(rent);
        
        return ResultViewModel<RentViewModel>.Success(rentDto);
    }
}