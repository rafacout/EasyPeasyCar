namespace EasyPeasy.Domain.Entities;

public class Store(string name, string address, string city, string state, string zip, string phone, string email)
    : BaseEntity
{
    public string Name { get; private set; } = name;
    public string Address { get; private set; } = address;
    public string City { get; private set; } = city;
    public string State { get; private set; } = state;
    public string Zip { get; private set; } = zip;
    public string Phone { get; private set; } = phone;
    public string Email { get; private set; } = email;

    public void Update(string name, string address, string city, string state, string zip, string phone, string email)
    {
        Name = name;
        Address = address;
        City = city;
        State = state;
        Zip = zip;
        Phone = phone;
        Email = email;
    }
}