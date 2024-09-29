namespace EasyPeasy.Application.DTOs;

public record VehicleDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public int Mileage { get; init; }
    public string LicensePlate { get; init; }
    public string Color { get; init; }
}