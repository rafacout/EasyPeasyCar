using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Commands.Model.DeleteModel;

public class DeleteModelCommandHandler : IRequestHandler<DeleteModelCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteModelCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        var model = await _unitOfWork.Models.GetByIdAsync(request.Id);
        
        if (model != null)
        {
            await _unitOfWork.Models.DeleteAsync(request.Id);
            await _unitOfWork.CompleteAsync();    
        }

        return Unit.Value;
    }
}