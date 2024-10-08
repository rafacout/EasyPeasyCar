using Asp.Versioning;
using EasyPeasy.Application.Queries.Login.GetLogin;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyPeasy.API.Controllers;

[AllowAnonymous]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IMediator _mediator;

    public LoginController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Login(GetLoginQuery login)
    {
        var user = await _mediator.Send(login);
        
        if (user == null)
        {
            return Unauthorized();
        }
        
        return Ok(user);
    }
}