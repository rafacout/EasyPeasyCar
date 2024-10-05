using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Queries.Login.GetLogin;

public class GetLoginQuery : IRequest<LoginUserDto?>
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}