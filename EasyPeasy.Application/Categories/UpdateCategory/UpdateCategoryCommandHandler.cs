using EasyPeasy.Application.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Categories.UpdateCategory;

public class UpdateCategoryCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateCategoryCommand, ResultDto<Guid>>
{
    public async Task<ResultDto<Guid>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.Categories.GetByIdAsync(request.Id);

        if (entity is null)
        {
            return ResultDto<Guid>.Failure("Category not found");
        }

        entity.Update(request.Name);
        unitOfWork.Categories.UpdateAsync(entity);
        await unitOfWork.CompleteAsync();

        return ResultDto<Guid>.Success(request.Id, "Category updated successfully");
    }
}