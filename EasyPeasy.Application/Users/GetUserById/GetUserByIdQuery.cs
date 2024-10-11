using EasyPeasy.Application.DTOs;
using EasyPeasy.Application.Users.DTOs;
using MediatR;

namespace EasyPeasy.Application.Users.GetUserById;

public class GetUserByIdQuery(Guid id) : IRequest<ResultDto<UserDto>>
{
    public Guid Id { get; set; } = id;
}