using EasyPeasy.Application.Commands.Manufacturer.CreateManufacturer;
using EasyPeasy.Application.Commands.Manufacturer.DeleteManufacturer;
using EasyPeasy.Application.Commands.Manufacturer.UpdateManufacturer;
using EasyPeasy.Application.Queries.Vehicle.GetAllVehicles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyPeasy.API.Controllers;

[Authorize]
[Route("api/[controller]")]
public class VehicleController : ControllerBase
{
    private readonly IMediator _mediator;

    public VehicleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categoriesQuery = new GetAllVehiclesQuery();
            
        var categories = await _mediator.Send(categoriesQuery);

        return Ok(categories);
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
