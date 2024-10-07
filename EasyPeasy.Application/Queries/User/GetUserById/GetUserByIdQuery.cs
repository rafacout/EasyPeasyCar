using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Queries.User.GetUserById;

public class GetUserByIdQuery : IRequest<UserDto>
{
    public GetUserByIdQuery(Guid id)
    {
        Id = id;
    }
    
    public Guid Id { get; set; }
}