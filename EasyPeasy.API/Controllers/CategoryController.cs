using EasyPeasy.Application.Queries.Category.GetAllCategories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyPeasy.API.Controllers;

[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categoriesQuery = new GetAllCategoriesQuery();
            
        var categories = await _mediator.Send(categoriesQuery);

        return Ok(categories);
    }
}