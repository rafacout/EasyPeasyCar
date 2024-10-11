using EasyPeasy.Application.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Stores.CreateStore;

public class CreateStoreCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateStoreCommand, ResultViewModel<Guid>>
{
    public async Task<ResultViewModel<Guid>> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
    {
        var store = new Domain.Entities.Store(request.Name, request.Address, request.City, request.State, request.Zip, request.Phone, request.Email);

        await unitOfWork.Stores.CreateAsync(store);
        await unitOfWork.CompleteAsync();

        return ResultViewModel<Guid>.Success(store.Id, "Store created successfully");
    }
}