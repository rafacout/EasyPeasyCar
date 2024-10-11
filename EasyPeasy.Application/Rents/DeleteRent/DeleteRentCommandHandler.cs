using EasyPeasy.Application.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Rents.DeleteRent;

public class DeleteRentCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteRentCommand, ResultViewModel<Guid>>
{
    public async Task<ResultViewModel<Guid>> Handle(DeleteRentCommand request, CancellationToken cancellationToken)
    {
        var rent = await unitOfWork.Rents.GetByIdAsync(request.Id);

        if (rent == null)
        {
            return ResultViewModel<Guid>.Failure("Rent not found");
        }

        await unitOfWork.Rents.DeleteAsync(request.Id);
        await unitOfWork.CompleteAsync();

        return ResultViewModel<Guid>.Success(request.Id, "Rent deleted successfully");
    }
}