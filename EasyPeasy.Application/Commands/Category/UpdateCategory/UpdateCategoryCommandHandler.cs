using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Commands.Category.UpdateCategory;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        var entity = await _unitOfWork.Categories.GetByIdAsync(request.Id);
        
        if (entity is not null)
        {
            entity.Update(request.Name);
            await _unitOfWork.Categories.UpdateAsync(entity);
            await _unitOfWork.CompleteAsync();
        }

        return Unit.Value;
    }
}