using EasyPeasy.Application.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Commands.Store.DeleteStore;

public class DeleteStoreCommandHandler : IRequestHandler<DeleteStoreCommand, ResultDto<Guid>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteStoreCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultDto<Guid>> Handle(DeleteStoreCommand request, CancellationToken cancellationToken)
    {
        var store = await _unitOfWork.Stores.GetByIdAsync(request.Id);

        if (store == null)
        {
            return ResultDto<Guid>.Failure("Store not found");
        }

        await _unitOfWork.Stores.DeleteAsync(request.Id);
        await _unitOfWork.CompleteAsync();

        return ResultDto<Guid>.Success(request.Id, "Store deleted successfully");
    }
}