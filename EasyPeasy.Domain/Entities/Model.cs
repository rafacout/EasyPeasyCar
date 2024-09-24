using System.Data;
using EasyPeasy.Domain.Enum;

namespace EasyPeasy.Domain.Entities;

public class Model : BaseEntity
{
    public Model(string name, int year, Guid manufacturerId, Guid categoryId, TransmissionType transmission, string motor)
    {
        Name = name;
        Year = year;
        ManufacturerId = manufacturerId;
        CategoryId = categoryId;
        Transmission = transmission;
        Motor = motor;
    }
    
    public string Name { get; private set; }
    public int Year { get; private set; }
    public Guid ManufacturerId { get; private set; }
    public Guid CategoryId { get; private set; }
    public TransmissionType Transmission { get; private set; }
    public string Motor { get; private set; }
    
    public Manufacturer Manufacturer { get; private set; }
    public Category Category { get; private set; }
}