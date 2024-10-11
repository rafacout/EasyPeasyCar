﻿using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Users.CreateUser;

public class CreateUserCommand : IRequest<ResultDto<Guid>>
{
    public string Email { get;  set; }
    public string Password { get;  set; }
    public string Role { get;  set; }
    public string Document { get;  set; }
    public string BirthDate { get;  set; }
    public string Phone { get;  set; }
    public string Address { get;  set; }
    public string City { get;  set; }
    public string State { get;  set; }
    public string Country { get;  set; }
    public string ZipCode { get;  set; }
}