﻿using MediatR;

namespace EasyPeasy.Application.Commands.User.DeleteUser;

public class DeleteUserCommand : IRequest<Unit>
{
    public DeleteUserCommand(Guid id)
    {
        Id = id;
    }
    
    public Guid Id { get; set; }
}