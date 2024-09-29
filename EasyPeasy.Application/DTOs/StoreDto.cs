namespace EasyPeasy.Application.DTOs;

public record StoreDto
{
    public Guid Id { get; set; }
    public string Name { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Email { get; private set; }
}