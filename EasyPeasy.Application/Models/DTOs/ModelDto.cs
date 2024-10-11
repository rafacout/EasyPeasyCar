namespace EasyPeasy.Application.Models.DTOs;

public record ModelDto
{
    public Guid Id { get; set; }
    public string Name { get; private set; }
    public int Year { get; private set; }
    public Guid ManufacturerId { get; private set; }
    public Guid CategoryId { get; private set; }
    public string Transmission { get; private set; }
    public string Motor { get; private set; }
}