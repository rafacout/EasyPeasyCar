using EasyPeasy.Application.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Users.DeleteUser;

public class DeleteUserCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteUserCommand, ResultDto<Guid>>
{
    public async Task<ResultDto<Guid>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.Users.GetByIdAsync(request.Id);

        if (user == null)
        {
            return ResultDto<Guid>.Failure("User not found");
        }

        await unitOfWork.Users.DeleteAsync(request.Id);
        await unitOfWork.CompleteAsync();

        return ResultDto<Guid>.Success(request.Id, "User deleted successfully");
    }
}