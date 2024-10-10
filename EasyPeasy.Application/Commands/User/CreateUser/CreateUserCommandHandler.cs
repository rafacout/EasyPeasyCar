using EasyPeasy.Application.Auth;
using EasyPeasy.Application.DTOs;
using EasyPeasy.Domain.Auth;
using EasyPeasy.Domain.Enum;
using EasyPeasy.Domain.Repositories;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Commands.User.CreateUser;

public class CreateUserCommandHandler(IAuthService authService, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateUserCommand, ResultDto<Guid>>
{
    public async Task<ResultDto<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var passwordHash = authService.ComputeSha256Hash(request.Password);
        
        var user = new Domain.Entities.User(request.Email, passwordHash,
            (RoleType)Enum.Parse(typeof(RoleType), request.Role), request.Document,
            request.Phone, request.Address, request.City, request.State, request.Country, request.ZipCode,
            DateOnly.Parse(request.BirthDate));
        
        await unitOfWork.Users.CreateAsync(user);
        await unitOfWork.CompleteAsync();

        return ResultDto<Guid>.Success(user.Id, "User created successfully");
    }
}