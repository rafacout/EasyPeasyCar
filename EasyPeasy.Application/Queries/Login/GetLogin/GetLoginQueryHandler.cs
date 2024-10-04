using EasyPeasy.Application.DTOs;
using EasyPeasy.Domain.Auth;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Queries.Login.GetLogin;

public class GetLoginQueryHandler : IRequestHandler<GetLoginQuery, LoginUserDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthService _authService;
    
    GetLoginQueryHandler(IUnitOfWork unitOfWork, IAuthService authService)
    {
        _unitOfWork = unitOfWork;
        _authService = authService;
    }
    
    public async Task<LoginUserDto> Handle(GetLoginQuery request, CancellationToken cancellationToken)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        
        var hashPassword = _authService.ComputeSha256Hash(request.Password);
        
        var user = await _unitOfWork.Users.GetByEmailAndPasswordAsync(request.Email, hashPassword);
        
        if (user == null)
        {
            return null;
        }
        
        var token = _authService.GenerateJwt(user.Email, user.Role.ToString());
        
        var userViewModel = new LoginUserDto(user.Email, user.Role.ToString(), token);

        return userViewModel;
    }
}