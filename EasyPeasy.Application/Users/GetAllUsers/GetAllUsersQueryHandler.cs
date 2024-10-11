using AutoMapper;
using EasyPeasy.Application.DTOs;
using EasyPeasy.Application.Users.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Users.GetAllUsers;

public class GetAllUsersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetAllUsersQuery, ResultDto<List<UserDto>>>
{
    public async Task<ResultDto<List<UserDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await unitOfWork.Users.GetAllAsync();

        var userDtos = mapper.Map<List<UserDto>>(users);
        
        return ResultDto<List<UserDto>>.Success(userDtos);
    }
}