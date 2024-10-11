using EasyPeasy.Application.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Stores.UpdateStore;

public class UpdateStoreCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateStoreCommand, ResultDto<Guid>>
{
    public async Task<ResultDto<Guid>> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
    {
        var store = await unitOfWork.Stores.GetByIdAsync(request.Id);

        if (store == null)
        {
            return ResultDto<Guid>.Failure("Store not found");
        }

        store.Update(request.Name, request.Address, request.City, request.State, request.Zip, request.Phone,
            request.Email);

        unitOfWork.Stores.UpdateAsync(store);

        await unitOfWork.CompleteAsync();

        return ResultDto<Guid>.Success(request.Id, "Store updated successfully");
    }
}