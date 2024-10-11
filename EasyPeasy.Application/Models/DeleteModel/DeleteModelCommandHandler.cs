using EasyPeasy.Application.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Models.DeleteModel;

public class DeleteModelCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteModelCommand, ResultViewModel<Guid>>
{
    public async Task<ResultViewModel<Guid>> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
    {
        var model = await unitOfWork.Models.GetByIdAsync(request.Id);

        if (model == null)
        {
            return ResultViewModel<Guid>.Failure("Model not found");
        }

        await unitOfWork.Models.DeleteAsync(request.Id);
        await unitOfWork.CompleteAsync();

        return ResultViewModel<Guid>.Success(request.Id, "Model deleted successfully");
    }
}