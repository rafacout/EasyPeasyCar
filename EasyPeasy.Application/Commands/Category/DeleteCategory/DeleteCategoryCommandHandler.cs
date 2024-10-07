using EasyPeasy.Application.Commands.Category.UpdateCategory;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Commands.Category.DeleteCategory;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        var category = await _unitOfWork.Categories.GetByIdAsync(request.Id);
        
        if (category != null)
        {
            await _unitOfWork.Categories.DeleteAsync(request.Id);
            await _unitOfWork.CompleteAsync();
        }
        
        return Unit.Value;
    }
}