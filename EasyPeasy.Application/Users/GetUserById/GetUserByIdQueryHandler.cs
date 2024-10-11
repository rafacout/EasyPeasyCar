using AutoMapper;
using EasyPeasy.Application.DTOs;
using EasyPeasy.Application.Users.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Users.GetUserById;

public class GetUserByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetUserByIdQuery, ResultDto<UserDto>>
{
    public async Task<ResultDto<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.Users.GetByIdAsync(request.Id);
        
        if (user == null)
        {
            return ResultDto<UserDto>.Failure($"User '{request.Id}' not exist.");
        }

        var userDto = mapper.Map<UserDto>(user);
        
        return ResultDto<UserDto>.Success(userDto);
    }
}