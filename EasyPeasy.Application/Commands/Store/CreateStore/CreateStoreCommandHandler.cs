using EasyPeasy.Application.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Commands.Store.CreateStore;

public class CreateStoreCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateStoreCommand, ResultDto<Guid>>
{
    public async Task<ResultDto<Guid>> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
    {
        var store = new Domain.Entities.Store(request.Name, request.Address, request.City, request.State, request.Zip, request.Phone, request.Email);

        await unitOfWork.Stores.CreateAsync(store);
        await unitOfWork.CompleteAsync();

        return ResultDto<Guid>.Success(store.Id, "Store created successfully");
    }
}