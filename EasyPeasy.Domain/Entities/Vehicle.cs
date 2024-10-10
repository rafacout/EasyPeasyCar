using EasyPeasy.Domain.Enum;

namespace EasyPeasy.Domain.Entities;

public class Vehicle(
    string documentId,
    string name,
    Guid modelId,
    float dailyRate,
    int mileage,
    string licensePlate,
    string color,
    StatusVehicle statusVehicle)
    : BaseEntity
{
    public string DocumentId { get; private set; } = documentId;
    public string Name { get; private set; } = name;
    public Guid ModelId { get; private set; } = modelId;
    public float DailyRate { get; private set; } = dailyRate;
    public int Mileage { get; private set; } = mileage;
    public string LicensePlate { get; private set; } = licensePlate;
    public string Color { get; private set; } = color;
    public StatusVehicle StatusVehicle { get; private set; } = statusVehicle;

    public Model? Model { get; private set; }
    
    public void Update(string documentId, string name, Guid modelId, float dailyRate, int mileage, string licensePlate, string color, StatusVehicle statusVehicle)
    {
        DocumentId = documentId;
        Name = name;
        ModelId = modelId;
        DailyRate = dailyRate;
        Mileage = mileage;
        LicensePlate = licensePlate;
        Color = color;
        StatusVehicle = statusVehicle;
    }
}