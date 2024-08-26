namespace EasyPeasy.Domain.Entities;

public class Manufacturer : BaseEntity
{
    public Manufacturer(string name, string country)
    {
        Name = name;
        Country = country;
    }
    
    public string Name { get; set; }
    public string Country { get; set; }
    
    public void Update(string name, string country)
    {
        Name = name;
        Country = country;
    }
}