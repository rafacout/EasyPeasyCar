using MediatR;

namespace EasyPeasy.Application.Commands.Store.CreateStore;

public class CreateStoreCommandHandler : IRequestHandler<CreateStoreCommand, int>
{
    public Task<int> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}