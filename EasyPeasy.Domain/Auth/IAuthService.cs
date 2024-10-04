namespace EasyPeasy.Domain.Auth;

public interface IAuthService
{
    string GenerateJwt(string email, string role);
}