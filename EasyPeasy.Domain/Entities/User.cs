using EasyPeasy.Domain.Enum;

namespace EasyPeasy.Domain.Entities;

public class User : BaseEntity
{
    public User(string email, string password, RoleType role, string document, string phone, string address, string city, string state, string country, string zipCode, DateOnly birthDate)
    {
        Email = email;
        Password = password;
        Role = role;
        Document = document;
        Phone = phone;
        Address = address;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipCode;
        BirthDate = birthDate;
    }
    
    public string Email { get; private set; }
    public string Password { get; private set; }
    public RoleType Role { get; private set; }
    public string Document { get; private set; }
    public DateOnly BirthDate { get; private set; }
    public string Phone { get; private set; }
    public string Address { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }
    public string ZipCode { get; private set; }

    public void Update(string email, string password, RoleType role, string document, string phone, string address, string city, string state, string country, string zipCode, DateOnly birthDate)
    {
        Email = email;
        Password = password;
        Role = role;
        Document = document;
        Phone = phone;
        Address = address;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipCode;
        BirthDate = birthDate;
    }

}