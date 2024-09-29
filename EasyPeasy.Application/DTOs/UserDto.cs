namespace EasyPeasy.Application.DTOs;

public record UserDto
{
    public Guid Id { get; set; }
    public string Email { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }
}