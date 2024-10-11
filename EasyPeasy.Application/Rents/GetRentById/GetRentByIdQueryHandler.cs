using AutoMapper;
using EasyPeasy.Application.DTOs;
using EasyPeasy.Application.Rents.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Rents.GetRentById;

public class GetRentByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetRentByIdQuery, ResultDto<RentDto>>
{
    public async Task<ResultDto<RentDto>> Handle(GetRentByIdQuery request, CancellationToken cancellationToken)
    {
        var rent = await unitOfWork.Rents.GetByIdAsync(request.Id);
        
        if (rent == null)
        {
            return ResultDto<RentDto>.Failure($"Rent '{request.Id}' not exist.");
        }

        var rentDto = mapper.Map<RentDto>(rent);
        
        return ResultDto<RentDto>.Success(rentDto);
    }
}