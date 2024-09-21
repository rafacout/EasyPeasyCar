namespace EasyPeasy.Domain.Entities;

public class Manufacturer : BaseEntity
{
    public Manufacturer(string name, string country)
    {
        Name = name;
        Country = country;
    }
    public string Name { get; private set; }
    public string Country { get; private set; }

    public IEnumerable<Model> Models { get; set; }
    
    public void Update(string name, string country)
    {
        Name = name;
        Country = country;
    }
}