namespace EasyPeasy.Application.DTOs;

public record StoreDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Email { get; set; }
}