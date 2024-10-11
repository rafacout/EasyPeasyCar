using EasyPeasy.Application.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Categories.DeleteCategory;

public class DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteCategoryCommand, ResultViewModel<Guid>>
{
    public async Task<ResultViewModel<Guid>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await unitOfWork.Categories.GetByIdAsync(request.Id);

        if (category == null)
        {
            return ResultViewModel<Guid>.Failure("Category not found");
        }

        await unitOfWork.Categories.DeleteAsync(request.Id);
        await unitOfWork.CompleteAsync();

        return ResultViewModel<Guid>.Success(request.Id, "Category deleted successfully");
    }
}