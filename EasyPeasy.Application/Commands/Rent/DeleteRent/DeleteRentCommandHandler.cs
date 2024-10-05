using System.Diagnostics;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Commands.Rent.DeleteRent;

public class DeleteRentCommandHandler : IRequestHandler<DeleteRentCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteRentCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request, nameof(request));
        
        var rent = await _unitOfWork.Rents.GetByIdAsync(request.Id);

        if (rent != null)
        {
            await _unitOfWork.Rents.DeleteAsync(request.Id);
            await _unitOfWork.CommitAsync();
        }

        return Unit.Value;
    }
}