using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Queries.User.GetUserById;

public class GetUserByIdQuery(Guid id) : IRequest<ResultDto<UserDto>>
{
    public Guid Id { get; set; } = id;
}