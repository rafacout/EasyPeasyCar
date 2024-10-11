using EasyPeasy.Application.DTOs;
using EasyPeasy.Domain.Enum;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Models.UpdateModel;

public class UpdateModelCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateModelCommand, ResultViewModel<Guid>>
{
    public async Task<ResultViewModel<Guid>> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
    {
        var model = await unitOfWork.Models.GetByIdAsync(request.Id);

        if (model == null)
        {
            return ResultViewModel<Guid>.Failure("Model not found");
        }

        model.Update(request.Name, request.Year, request.ManufacturerId, request.CategoryId,
            (TransmissionType)Enum.Parse(typeof(TransmissionType), request.Transmission), request.Motor);
        unitOfWork.Models.UpdateAsync(model);
        await unitOfWork.CompleteAsync();

        return ResultViewModel<Guid>.Success(request.Id, "Model updated successfully");
    }
}