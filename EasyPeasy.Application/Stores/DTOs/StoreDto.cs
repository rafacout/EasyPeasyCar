namespace EasyPeasy.Application.Stores.DTOs;

public record StoreDto
{
    public Guid Id { get; set; }
    public string Name { get; private set; }
    public string Address { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Zip { get; private set; }
    public string Phone { get; private set; }
    public string Email { get; private set; }
}