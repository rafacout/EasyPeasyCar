using EasyPeasy.Application.DTOs;
using EasyPeasy.Domain.Auth;
using EasyPeasy.Domain.Enum;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Users.CreateUser;

public class CreateUserCommandHandler(IAuthService authService, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateUserCommand, ResultViewModel<Guid>>
{
    public async Task<ResultViewModel<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var passwordHash = authService.ComputeSha256Hash(request.Password);
        
        var user = new Domain.Entities.User(request.Email, passwordHash,
            (RoleType)Enum.Parse(typeof(RoleType), request.Role), request.Document,
            request.Phone, request.Address, request.City, request.State, request.Country, request.ZipCode,
            DateOnly.Parse(request.BirthDate));
        
        await unitOfWork.Users.CreateAsync(user);
        await unitOfWork.CompleteAsync();

        return ResultViewModel<Guid>.Success(user.Id, "User created successfully");
    }
}