using EasyPeasy.Application.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Commands.Model.DeleteModel;

public class DeleteModelCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteModelCommand, ResultDto<Guid>>
{
    public async Task<ResultDto<Guid>> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
    {
        var model = await unitOfWork.Models.GetByIdAsync(request.Id);

        if (model == null)
        {
            return ResultDto<Guid>.Failure("Model not found");
        }

        await unitOfWork.Models.DeleteAsync(request.Id);
        await unitOfWork.CompleteAsync();

        return ResultDto<Guid>.Success(request.Id, "Model deleted successfully");
    }
}