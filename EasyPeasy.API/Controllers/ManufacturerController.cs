using EasyPeasy.Application.Commands.Manufacturer.CreateManufacturer;
using EasyPeasy.Application.Commands.Manufacturer.DeleteManufacturer;
using EasyPeasy.Application.Commands.Manufacturer.UpdateManufacturer;
using EasyPeasy.Application.Queries.Manufacturer.GetAllManufacturers;
using EasyPeasy.Application.Queries.Manufacturer.GetManufacturerById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyPeasy.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ManufacturerController : ControllerBase
{
    private readonly IMediator _mediator;

    public ManufacturerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var manufacturersQuery = new GetAllManufacturersQuery();
            
        var manufacturers = await _mediator.Send(manufacturersQuery);

        return Ok(manufacturers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var manufacturerQuery = new GetManufacturerByIdQuery(id);
            
        var manufacturer = await _mediator.Send(manufacturerQuery);

        return Ok(manufacturer);
        
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
