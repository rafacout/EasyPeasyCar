using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Commands.Store.DeleteStore;

public class DeleteStoreCommandHandler : IRequestHandler<DeleteStoreCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteStoreCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteStoreCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request, nameof(request));
        
        var store = await _unitOfWork.Stores.GetByIdAsync(request.Id);
        
        if (store != null)
        {
            await _unitOfWork.Stores.DeleteAsync(request.Id);
            await _unitOfWork.CompleteAsync();
        }
        
        return Unit.Value;
    }
}