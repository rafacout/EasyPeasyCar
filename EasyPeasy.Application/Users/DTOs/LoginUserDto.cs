namespace EasyPeasy.Application.Users.DTOs;

public record LoginUserDto
{
    public string UserName { get; set; }
    public string Role { get; set; }
    public string Token { get; set; }
}