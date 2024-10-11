using EasyPeasy.Application.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Categories.UpdateCategory;

public class UpdateCategoryCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateCategoryCommand, ResultViewModel<Guid>>
{
    public async Task<ResultViewModel<Guid>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.Categories.GetByIdAsync(request.Id);

        if (entity is null)
        {
            return ResultViewModel<Guid>.Failure("Category not found");
        }

        entity.Update(request.Name);
        unitOfWork.Categories.UpdateAsync(entity);
        await unitOfWork.CompleteAsync();

        return ResultViewModel<Guid>.Success(request.Id, "Category updated successfully");
    }
}