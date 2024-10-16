﻿using Asp.Versioning;
using EasyPeasy.Application.Users.CreateUser;
using EasyPeasy.Application.Users.DeleteUser;
using EasyPeasy.Application.Users.GetAllUsers;
using EasyPeasy.Application.Users.GetUserById;
using EasyPeasy.Application.Users.UpdateUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyPeasy.API.Controllers;

[Authorize]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categoriesQuery = new GetAllUsersQuery();
            
        var categories = await _mediator.Send(categoriesQuery);

        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var userQuery = new GetUserByIdQuery(id);
            
        var user = await _mediator.Send(userQuery);

        return Ok(user);
    }
    
    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody]CreateUserCommand command)
    {
        var result = await _mediator.Send(command);

        return Created("", result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody]UpdateUserCommand command)
    {
        await _mediator.Send(command);
            
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteUserCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }
}
