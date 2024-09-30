using MediatR;

namespace EasyPeasy.Application.Commands.Rent.DeleteRent;

class DeleteRentCommandHandler : IRequestHandler<DeleteRentCommand, Unit>
{
    public Task<Unit> Handle(DeleteRentCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}