using EasyPeasy.Domain.Enum;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Commands.Model.UpdateModel;

public class UpdateModelCommandHandler : IRequestHandler<UpdateModelCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateModelCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var model = await _unitOfWork.Models.GetByIdAsync(request.Id);

        if (model != null)
        {
            model.Update(request.Name, request.Year, request.ManufacturerId, request.CategoryId,
                (TransmissionType)Enum.Parse(typeof(TransmissionType), request.Transmission), request.Motor);
            await _unitOfWork.CommitAsync();
        }

        return Unit.Value;
    }
}