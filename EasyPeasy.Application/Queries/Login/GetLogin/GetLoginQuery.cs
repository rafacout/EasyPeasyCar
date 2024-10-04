using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Queries.Login.GetLogin;

public class GetLoginQuery : IRequest<LoginUserDto?>
{
    public string Email { get; set; }
    public string Password { get; set; }
}