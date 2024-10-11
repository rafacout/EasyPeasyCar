using EasyPeasy.Application.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Rents.DeleteRent;

public class DeleteRentCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteRentCommand, ResultDto<Guid>>
{
    public async Task<ResultDto<Guid>> Handle(DeleteRentCommand request, CancellationToken cancellationToken)
    {
        var rent = await unitOfWork.Rents.GetByIdAsync(request.Id);

        if (rent == null)
        {
            return ResultDto<Guid>.Failure("Rent not found");
        }

        await unitOfWork.Rents.DeleteAsync(request.Id);
        await unitOfWork.CompleteAsync();

        return ResultDto<Guid>.Success(request.Id, "Rent deleted successfully");
    }
}