using EasyPeasy.Application.Commands.Category.UpdateCategory;
using EasyPeasy.Application.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Commands.Category.DeleteCategory;

public class DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteCategoryCommand, ResultDto<Guid>>
{
    public async Task<ResultDto<Guid>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await unitOfWork.Categories.GetByIdAsync(request.Id);

        if (category == null)
        {
            return ResultDto<Guid>.Failure("Category not found");
        }

        await unitOfWork.Categories.DeleteAsync(request.Id);
        await unitOfWork.CompleteAsync();

        //TODO Return Guid instead of Unit
        return ResultDto<Guid>.Success(request.Id, "Category deleted successfully");
    }
}