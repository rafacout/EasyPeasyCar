namespace EasyPeasy.Application.DTOs;

public record ManufacturerDto
{
    public int ManufacturerId { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
}