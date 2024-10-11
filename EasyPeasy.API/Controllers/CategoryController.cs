using Asp.Versioning;
using EasyPeasy.Application.Categories.CreateCategory;
using EasyPeasy.Application.Categories.DeleteCategory;
using EasyPeasy.Application.Categories.GetAllCategories;
using EasyPeasy.Application.Categories.GetCategoryById;
using EasyPeasy.Application.Categories.UpdateCategory;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyPeasy.API.Controllers;

[Authorize]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // TODO Fix all warnings
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categoriesQuery = new GetAllCategoriesQuery();
            
        var categories = await _mediator.Send(categoriesQuery);

        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var categoryQuery = new GetCategoryByIdQuery(id);
            
        var category = await _mediator.Send(categoryQuery);

        //TODO Fix result pattern to return http status
        return Ok(category);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody]CreateCategoryCommand command)
    {
        var result = await _mediator.Send(command);

        return Created("", result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody]UpdateCategoryCommand command)
    {
        await _mediator.Send(command);
            
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteCategoryCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }
}
