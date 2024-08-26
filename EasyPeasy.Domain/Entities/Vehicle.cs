namespace EasyPeasy.Domain.Entities;

public class Vehicle : BaseEntity
{
    public Vehicle(string name, Model model, float dailyRate)
    {
        Name = name;
        Model = model;
        DailyRate = dailyRate;
    }
    public string Name { get; set; }
    public Model Model { get; set; }

    public float DailyRate { get; set; }

    public void Update(string name, Model model)
    {
        Name = name;
        Model = model;
    }
}