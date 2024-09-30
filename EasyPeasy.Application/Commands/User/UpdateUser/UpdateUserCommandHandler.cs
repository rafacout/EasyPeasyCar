using MediatR;

namespace EasyPeasy.Application.Commands.User.UpdateUser;

class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
{
    public Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}