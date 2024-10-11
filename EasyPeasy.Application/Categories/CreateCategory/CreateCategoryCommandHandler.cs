using EasyPeasy.Application.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Categories.CreateCategory;

public class CreateCategoryCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CreateCategoryCommand, ResultViewModel<Guid>>
{
    public async Task<ResultViewModel<Guid>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Domain.Entities.Category(request.Name);
        var id = await unitOfWork.Categories.CreateAsync(category);
        await unitOfWork.CompleteAsync();
        return ResultViewModel<Guid>.Success(id, "Category created successfully");
    }
}