namespace EasyPeasy.Application.DTOs;

public record UserDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
}