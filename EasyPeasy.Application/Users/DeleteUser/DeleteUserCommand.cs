using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Users.DeleteUser;

public class DeleteUserCommand(Guid id) : IRequest<ResultViewModel<Guid>>
{
    public Guid Id { get; set; } = id;
}