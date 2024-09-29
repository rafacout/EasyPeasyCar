using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Queries.User.GetAllUsers;

public class GetAllUsersQuery : IRequest<List<UserDto>>
{
}