using EasyPeasy.Application.DTOs;
using EasyPeasy.Domain.Enum;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Commands.Model.UpdateModel;

public class UpdateModelCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateModelCommand, ResultDto<Guid>>
{
    public async Task<ResultDto<Guid>> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
    {
        var model = await unitOfWork.Models.GetByIdAsync(request.Id);

        if (model == null)
        {
            return ResultDto<Guid>.Failure("Model not found");
        }

        model.Update(request.Name, request.Year, request.ManufacturerId, request.CategoryId,
            (TransmissionType)Enum.Parse(typeof(TransmissionType), request.Transmission), request.Motor);
        unitOfWork.Models.UpdateAsync(model);
        await unitOfWork.CompleteAsync();

        return ResultDto<Guid>.Success(request.Id, "Model updated successfully");
    }
}