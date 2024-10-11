using EasyPeasy.Application.DTOs;
using EasyPeasy.Application.Users.DTOs;
using MediatR;

namespace EasyPeasy.Application.Users.GetLogin;

public class GetLoginQuery : IRequest<ResultDto<LoginUserDto>>
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}