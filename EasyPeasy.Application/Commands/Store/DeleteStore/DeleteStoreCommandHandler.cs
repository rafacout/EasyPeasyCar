using MediatR;

namespace EasyPeasy.Application.Commands.Store.DeleteStore;

public class DeleteStoreCommandHandler : IRequestHandler<DeleteStoreCommand, Unit>
{
    public Task<Unit> Handle(DeleteStoreCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}