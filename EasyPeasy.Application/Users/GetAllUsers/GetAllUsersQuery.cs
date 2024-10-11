using EasyPeasy.Application.DTOs;
using EasyPeasy.Application.Users.DTOs;
using MediatR;

namespace EasyPeasy.Application.Users.GetAllUsers;

public class GetAllUsersQuery : IRequest<ResultViewModel<List<UserViewModel>>>
{
}