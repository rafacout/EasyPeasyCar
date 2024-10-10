using EasyPeasy.Domain.Enum;

namespace EasyPeasy.Domain.Entities;

public class User(
    string email,
    string password,
    RoleType role,
    string document,
    string phone,
    string address,
    string city,
    string state,
    string country,
    string zipCode,
    DateOnly birthDate)
    : BaseEntity
{
    public string Email { get; private set; } = email;
    public string Password { get; private set; } = password;
    public RoleType Role { get; private set; } = role;
    public string Document { get; private set; } = document;
    public DateOnly BirthDate { get; private set; } = birthDate;
    public string Phone { get; private set; } = phone;
    public string Address { get; private set; } = address;
    public string City { get; private set; } = city;
    public string State { get; private set; } = state;
    public string Country { get; private set; } = country;
    public string ZipCode { get; private set; } = zipCode;

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