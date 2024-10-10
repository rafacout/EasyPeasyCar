namespace EasyPeasy.Domain.Entities;

public class Manufacturer(string name, string country) : BaseEntity
{
    public string Name { get; private set; } = name;
    public string Country { get; private set; } = country;

    public IEnumerable<Model>? Models { get; set; }
    
    public void Update(string name, string country)
    {
        Name = name;
        Country = country;
    }
}