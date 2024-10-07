using EasyPeasy.Application.Commands.Category.CreateCategory;
using EasyPeasy.Application.Commands.Category.DeleteCategory;
using EasyPeasy.Application.Commands.Category.UpdateCategory;
using EasyPeasy.Application.Queries.Category.GetAllCategories;
using EasyPeasy.Application.Queries.Category.GetCategoryById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyPeasy.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // TODO Rename all metod names to have Async???
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
