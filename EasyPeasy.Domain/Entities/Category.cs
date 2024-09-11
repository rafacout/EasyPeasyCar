namespace EasyPeasy.Domain.Entities;

public class Category : BaseEntity
{
    public Category(string name)
    {
        Name = name;
    }
    
    public string Name { get; set; }

    public IEnumerable<Model> Models { get; set; }
    
    public void Update(string name)
    {
        Name = name;
    }
}