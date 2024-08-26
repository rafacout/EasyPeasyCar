namespace EasyPeasy.Domain.Entities;

public class Model : BaseEntity
{
    public Model(string name, Manufacturer manufacturer)
    {
        Name = name;
        Manufacturer = manufacturer;
    }
    
    public string Name { get; set; }
    public Manufacturer Manufacturer { get; set; }
    
    public void Update(string name, Manufacturer manufacturer)
    {
        Name = name;
        Manufacturer = manufacturer;
    }
}