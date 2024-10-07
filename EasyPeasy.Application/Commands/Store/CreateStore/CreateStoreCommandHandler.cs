using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Commands.Store.CreateStore;

public class CreateStoreCommandHandler : IRequestHandler<CreateStoreCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateStoreCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request, nameof(request));

        var store = new Domain.Entities.Store(request.Name, request.Address, request.City, request.State, request.Zip, request.Phone, request.Email);

        await _unitOfWork.Stores.CreateAsync(store);
        await _unitOfWork.CompleteAsync();

        return store.Id;
    }
}