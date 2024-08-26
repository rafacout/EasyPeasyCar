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
    
    public string Name { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    
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