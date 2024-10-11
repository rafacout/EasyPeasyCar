using EasyPeasy.Application.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Stores.UpdateStore;

public class UpdateStoreCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateStoreCommand, ResultViewModel<Guid>>
{
    public async Task<ResultViewModel<Guid>> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
    {
        var store = await unitOfWork.Stores.GetByIdAsync(request.Id);

        if (store == null)
        {
            return ResultViewModel<Guid>.Failure("Store not found");
        }

        store.Update(request.Name, request.Address, request.City, request.State, request.Zip, request.Phone,
            request.Email);

        unitOfWork.Stores.UpdateAsync(store);

        await unitOfWork.CompleteAsync();

        return ResultViewModel<Guid>.Success(request.Id, "Store updated successfully");
    }
}