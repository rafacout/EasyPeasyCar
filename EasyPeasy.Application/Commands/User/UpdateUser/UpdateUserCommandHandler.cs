using EasyPeasy.Application.DTOs;
using EasyPeasy.Domain.Enum;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Commands.User.UpdateUser;

public class UpdateUserCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateUserCommand, ResultDto<Guid>>
{
    public async Task<ResultDto<Guid>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.Users.GetByIdAsync(request.Id);

        if (user == null)
        {
            return ResultDto<Guid>.Failure("User not found");
        }

        user.Update(request.Email, request.Password, (RoleType)Enum.Parse(typeof(RoleType), request.Role),
            request.Document, request.Phone, request.Address, request.City, request.State, request.Country,
            request.ZipCode, DateOnly.Parse(request.BirthDate));

        unitOfWork.Users.UpdateAsync(user);

        await unitOfWork.CompleteAsync();

        return ResultDto<Guid>.Success(request.Id, "User updated successfully");
    }
}