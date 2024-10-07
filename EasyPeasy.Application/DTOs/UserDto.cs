namespace EasyPeasy.Application.DTOs;

public record UserDto
{
    public Guid Id { get; set; }
    public string Email { get; private set; }
    public string Role { get; private set; }
    public string Document { get; private set; }
    public DateOnly BirthDate { get; private set; }
    public string Phone { get; private set; }
    public string Address { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }
    public string ZipCode { get; private set; }
}