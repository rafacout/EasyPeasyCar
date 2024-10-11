namespace EasyPeasy.Application.Users.DTOs;

public record LoginViewModel
{
    public string UserName { get; set; }
    public string Role { get; set; }
    public string Token { get; set; }
}