using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Users.DeleteUser;

public class DeleteUserCommand(Guid id) : IRequest<ResultDto<Guid>>
{
    public Guid Id { get; set; } = id;
}