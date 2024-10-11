using Asp.Versioning;
using EasyPeasy.Application.Rents.CreateRent;
using EasyPeasy.Application.Rents.DeleteRent;
using EasyPeasy.Application.Rents.GetAllRents;
using EasyPeasy.Application.Rents.GetRentById;
using EasyPeasy.Application.Rents.UpdateRent;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyPeasy.API.Controllers;

[Authorize]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class RentController : ControllerBase
{
    private readonly IMediator _mediator;

    public RentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categoriesQuery = new GetAllRentsQuery();
            
        var categories = await _mediator.Send(categoriesQuery);

        return Ok(categories);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var rentQuery = new GetRentByIdQuery(id);
            
        var rent = await _mediator.Send(rentQuery);

        return Ok(rent);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody]CreateRentCommand command)
    {
        var result = await _mediator.Send(command);

        return Created("", result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody]UpdateRentCommand command)
    {
        await _mediator.Send(command);
            
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteRentCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }
}
