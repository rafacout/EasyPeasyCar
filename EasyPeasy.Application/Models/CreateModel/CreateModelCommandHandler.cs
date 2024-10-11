using EasyPeasy.Application.DTOs;
using EasyPeasy.Domain.Enum;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Models.CreateModel;

public class CreateModelCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateModelCommand, ResultDto<Guid>>
{
    public async Task<ResultDto<Guid>> Handle(CreateModelCommand request, CancellationToken cancellationToken)
    {
        var model = new Domain.Entities.Model(request.Name, request.Year, request.ManufacturerId, request.CategoryId,
            (TransmissionType)Enum.Parse(typeof(TransmissionType), request.Transmission), request.Motor);

        await unitOfWork.Models.CreateAsync(model);
        await unitOfWork.CompleteAsync();

        return ResultDto<Guid>.Success(model.Id, "Model created successfully");
    }
}