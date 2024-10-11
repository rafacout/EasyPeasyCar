namespace EasyPeasy.Application.Manufacturers.DTOs;

public record ManufacturerViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
}