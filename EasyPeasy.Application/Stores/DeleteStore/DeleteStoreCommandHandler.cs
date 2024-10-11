using EasyPeasy.Application.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Stores.DeleteStore;

public class DeleteStoreCommandHandler : IRequestHandler<DeleteStoreCommand, ResultViewModel<Guid>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteStoreCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultViewModel<Guid>> Handle(DeleteStoreCommand request, CancellationToken cancellationToken)
    {
        var store = await _unitOfWork.Stores.GetByIdAsync(request.Id);

        if (store == null)
        {
            return ResultViewModel<Guid>.Failure("Store not found");
        }

        await _unitOfWork.Stores.DeleteAsync(request.Id);
        await _unitOfWork.CompleteAsync();

        return ResultViewModel<Guid>.Success(request.Id, "Store deleted successfully");
    }
}