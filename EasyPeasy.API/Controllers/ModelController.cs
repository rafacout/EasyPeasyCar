using Asp.Versioning;
using EasyPeasy.Application.Models.CreateModel;
using EasyPeasy.Application.Models.DeleteModel;
using EasyPeasy.Application.Models.GetAllModels;
using EasyPeasy.Application.Models.GetModelById;
using EasyPeasy.Application.Models.UpdateModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyPeasy.API.Controllers;

[Authorize]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class ModelController : ControllerBase
{
    private readonly IMediator _mediator;

    public ModelController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categoriesQuery = new GetAllModelsQuery();
            
        var categories = await _mediator.Send(categoriesQuery);

        return Ok(categories);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var modelQuery = new GetModelByIdQuery(id);
            
        var model = await _mediator.Send(modelQuery);

        return Ok(model);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody]CreateModelCommand command)
    {
        var result = await _mediator.Send(command);

        return Created("", result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody]UpdateModelCommand command)
    {
        await _mediator.Send(command);
            
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteModelCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }
}
