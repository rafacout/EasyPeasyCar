namespace EasyPeasy.Domain.Entities;

public class Category(string name) : BaseEntity
{
    public string Name { get; set; } = name;

    public IEnumerable<Model>? Models { get; set; }
    
    public void Update(string name)
    {
        Name = name;
    }
}