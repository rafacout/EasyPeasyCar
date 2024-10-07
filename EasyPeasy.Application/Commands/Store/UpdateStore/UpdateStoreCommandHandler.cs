using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Commands.Store.UpdateStore;

public class UpdateStoreCommandHandler : IRequestHandler<UpdateStoreCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateStoreCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request, nameof(request));
        
        var store = await _unitOfWork.Stores.GetByIdAsync(request.Id);

        if (store != null)
        {
            store.Update(request.Name, request.Address, request.City, request.State, request.Zip, request.Phone, request.Email);

            await _unitOfWork.Stores.UpdateAsync(store);
            
            await _unitOfWork.CompleteAsync();    
        }

        return Unit.Value;
    }
}