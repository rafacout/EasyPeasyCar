using EasyPeasy.Domain.Enum;

namespace EasyPeasy.Domain.Entities;

public class Vehicle : BaseEntity
{
    public Vehicle(string documentId, string name, Guid modelId, float dailyRate, Guid categoryId, int mileage, string licensePlate, string color, StatusVehicle statusVehicle)
    {
        DocumentId = documentId;
        Name = name;
        ModelId = modelId;
        DailyRate = dailyRate;
        CategoryId = categoryId;
        Mileage = mileage;
        LicensePlate = licensePlate;
        Color = color;
        StatusVehicle = statusVehicle;
    }
    
    public string DocumentId { get; private set; }
    public string Name { get; private set; }
    public Guid ModelId { get; private set; }
    public Guid CategoryId { get; private set; }
    public float DailyRate { get; private set; }

    public int Mileage { get; private set; }

    public string LicensePlate { get; private set; }

    public string Color { get; private set; }

    public StatusVehicle StatusVehicle { get; private set; }
    
    public Model Model { get; private set; }
    
    public Category Category { get; private set; }
    
    public void Update(string documentId, string name, Guid modelId, float dailyRate, Guid categoryId, int mileage, string licensePlate, string color, StatusVehicle statusVehicle)
    {
        DocumentId = documentId;
        Name = name;
        ModelId = modelId;
        DailyRate = dailyRate;
        CategoryId = categoryId;
        Mileage = mileage;
        LicensePlate = licensePlate;
        Color = color;
        StatusVehicle = statusVehicle;
    }
}