using EasyPeasy.Application.Commands.Model.CreateModel;
using EasyPeasy.Application.Commands.Model.DeleteModel;
using EasyPeasy.Application.Commands.Model.UpdateModel;
using EasyPeasy.Application.Queries.Model.GetAllModels;
using EasyPeasy.Application.Queries.Model.GetModelById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyPeasy.API.Controllers;

[Authorize]
[Route("api/[controller]")]
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
    
    [HttpGet("id")]
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
