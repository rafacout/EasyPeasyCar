using EasyPeasy.Application.Commands.Manufacturer.CreateManufacturer;
using EasyPeasy.Application.Commands.Manufacturer.DeleteManufacturer;
using EasyPeasy.Application.Commands.Manufacturer.UpdateManufacturer;
using EasyPeasy.Application.Queries.Rent.GetAllRents;
using EasyPeasy.Application.Queries.Rent.GetRentById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyPeasy.API.Controllers;

[Authorize]
[Route("api/[controller]")]
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
    
    [HttpGet("id")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var rentQuery = new GetRentByIdQuery(id);
            
        var rent = await _mediator.Send(rentQuery);

        return Ok(rent);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody]CreateManufacturerCommand command)
    {
        var result = await _mediator.Send(command);

        return Created("", result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody]UpdateManufacturerCommand command)
    {
        await _mediator.Send(command);
            
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteManufacturerCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }
}
