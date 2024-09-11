namespace EasyPeasy.Domain.Entities;

public class Store : BaseEntity
{
    public Store(string name, string address, string city, string state, string zip, string phone, string email)
    {
        Name = name;
        Address = address;
        City = city;
        State = state;
        Zip = zip;
        Phone = phone;
        Email = email;
    }
    
    public string Name { get; private set; }
    public string Address { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Zip { get; private set; }
    public string Phone { get; private set; }
    public string Email { get; private set; }
    
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