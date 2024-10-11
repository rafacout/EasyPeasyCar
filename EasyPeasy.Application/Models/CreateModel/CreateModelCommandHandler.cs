using EasyPeasy.Application.DTOs;
using EasyPeasy.Domain.Enum;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Models.CreateModel;

public class CreateModelCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateModelCommand, ResultViewModel<Guid>>
{
    public async Task<ResultViewModel<Guid>> Handle(CreateModelCommand request, CancellationToken cancellationToken)
    {
        var model = new Domain.Entities.Model(request.Name, request.Year, request.ManufacturerId, request.CategoryId,
            (TransmissionType)Enum.Parse(typeof(TransmissionType), request.Transmission), request.Motor);

        await unitOfWork.Models.CreateAsync(model);
        await unitOfWork.CompleteAsync();

        return ResultViewModel<Guid>.Success(model.Id, "Model created successfully");
    }
}