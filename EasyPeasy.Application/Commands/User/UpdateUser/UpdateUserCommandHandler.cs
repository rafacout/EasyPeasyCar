using EasyPeasy.Domain.Enum;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Commands.User.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var user = await _unitOfWork.Users.GetByIdAsync(request.Id);

        if (user != null)
        {
            user.Update(request.Email, request.Password, (RoleType)Enum.Parse(typeof(RoleType), request.Role),
                request.Document, request.Phone, request.Address, request.City, request.State, request.Country,
                request.ZipCode, DateOnly.Parse(request.BirthDate));

            await _unitOfWork.Users.UpdateAsync(user);
            
            await _unitOfWork.CompleteAsync();
        }

        return Unit.Value;
    }
}