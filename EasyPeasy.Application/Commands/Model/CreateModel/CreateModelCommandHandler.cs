using EasyPeasy.Domain.Enum;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Commands.Model.CreateModel;

public class CreateModelCommandHandler : IRequestHandler<CreateModelCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateModelCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateModelCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var model = new Domain.Entities.Model(request.Name, request.Year, request.ManufacturerId, request.CategoryId,
            (TransmissionType)Enum.Parse(typeof(TransmissionType), request.Transmission), request.Motor);

        await _unitOfWork.Models.CreateAsync(model);
        await _unitOfWork.CompleteAsync();

        return model.Id;
    }
}