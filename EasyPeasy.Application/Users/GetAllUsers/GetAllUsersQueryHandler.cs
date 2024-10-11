using AutoMapper;
using EasyPeasy.Application.DTOs;
using EasyPeasy.Application.Users.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Users.GetAllUsers;

public class GetAllUsersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetAllUsersQuery, ResultViewModel<List<UserViewModel>>>
{
    public async Task<ResultViewModel<List<UserViewModel>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await unitOfWork.Users.GetAllAsync();

        var userDtos = mapper.Map<List<UserViewModel>>(users);
        
        return ResultViewModel<List<UserViewModel>>.Success(userDtos);
    }
}