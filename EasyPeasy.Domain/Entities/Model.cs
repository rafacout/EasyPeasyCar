using System.Data;
using EasyPeasy.Domain.Enum;

namespace EasyPeasy.Domain.Entities;

public class Model(
    string name,
    int year,
    Guid manufacturerId,
    Guid categoryId,
    TransmissionType transmission,
    string motor)
    : BaseEntity
{
    public string Name { get; private set; } = name;
    public int Year { get; private set; } = year;
    public Guid ManufacturerId { get; private set; } = manufacturerId;
    public Guid CategoryId { get; private set; } = categoryId;
    public TransmissionType Transmission { get; private set; } = transmission;
    public string Motor { get; private set; } = motor;

    public Manufacturer? Manufacturer { get; private set; }
    public Category? Category { get; private set; }

    public void Update(string name, int year, Guid manufacturerId, Guid categoryId, TransmissionType transmission,
        string motor)
    {
        Name = name;
        Year = year;
        ManufacturerId = manufacturerId;
        CategoryId = categoryId;
        Transmission = transmission;
        Motor = motor;
    }
}