using EasyPeasy.Application.DTOs;
using EasyPeasy.Application.Users.DTOs;
using EasyPeasy.Domain.Auth;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Users.GetLogin;

public class GetLoginQueryHandler(IUnitOfWork unitOfWork, IAuthService authService)
    : IRequestHandler<GetLoginQuery, ResultDto<LoginUserDto>>
{
    public async Task<ResultDto<LoginUserDto>> Handle(GetLoginQuery request, CancellationToken cancellationToken)
    {
        var hashPassword = authService.ComputeSha256Hash(request.Password);
        
        var user = await unitOfWork.Users.GetByEmailAndPasswordAsync(request.Email, hashPassword);
        
        if (user == null)
        {
            return ResultDto<LoginUserDto>.Failure("Invalid email or password");
        }
        
        var token = authService.GenerateJwt(user.Email, user.Role.ToString());

        var userViewModel = new LoginUserDto()
        {
            UserName = user.Email,
            Role = user.Role.ToString(),
            Token = token
        };

        return ResultDto<LoginUserDto>.Success(userViewModel);
    }
}