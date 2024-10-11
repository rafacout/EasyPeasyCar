using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Vehicles.UpdateVehicle;

public class UpdateVehicleCommand : IRequest<ResultViewModel<Guid>>
{
    public Guid Id { get; set; }
    public string DocumentId { get; set; }
    public string Name { get; set; }
    public Guid ModelId { get; set; }
    public float DailyRate { get; set; }
    public int Mileage { get; set; }
    public string LicensePlate { get; set; }
    public string Color { get; set; }
    public string StatusVehicle { get; set; }
}