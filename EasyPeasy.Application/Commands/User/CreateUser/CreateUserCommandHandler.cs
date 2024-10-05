using EasyPeasy.Application.Auth;
using EasyPeasy.Domain.Auth;
using EasyPeasy.Domain.Enum;
using EasyPeasy.Domain.Repositories;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Commands.User.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthService _authService;

    public CreateUserCommandHandler(IAuthService authService, IUnitOfWork unitOfWork)
    {
        _authService = authService;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var passwordHash = _authService.ComputeSha256Hash(request.Password);
        
        var user = new Domain.Entities.User(request.Email, passwordHash,
            (RoleType)Enum.Parse(typeof(RoleType), request.Role), request.Document,
            request.Phone, request.Address, request.City, request.State, request.Country, request.ZipCode,
            DateOnly.Parse(request.BirthDate));
        
        await _unitOfWork.Users.CreateAsync(user);
        await _unitOfWork.CompleteAsync();

        return user.Id;
    }
}