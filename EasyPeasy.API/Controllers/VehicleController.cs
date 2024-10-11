using Asp.Versioning;
using EasyPeasy.Application.Vehicles.CreateVehicle;
using EasyPeasy.Application.Vehicles.DeleteVehicle;
using EasyPeasy.Application.Vehicles.GetAllVehicles;
using EasyPeasy.Application.Vehicles.GetVehicleById;
using EasyPeasy.Application.Vehicles.UpdateVehicle;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyPeasy.API.Controllers;

[Authorize]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
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
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var vehicleQuery = new GetVehicleByIdQuery(id);
            
        var vehicle = await _mediator.Send(vehicleQuery);

        return Ok(vehicle);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody]CreateVehicleCommand command)
    {
        var result = await _mediator.Send(command);

        return Created("", result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody]UpdateVehicleCommand command)
    {
        await _mediator.Send(command);
            
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteVehicleCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }
}
