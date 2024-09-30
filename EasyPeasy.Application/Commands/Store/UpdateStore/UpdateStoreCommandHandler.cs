using MediatR;

namespace EasyPeasy.Application.Commands.Store.UpdateStore;

class UpdateStoreCommandHandler : IRequestHandler<UpdateStoreCommand, Unit>
{
    public Task<Unit> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}