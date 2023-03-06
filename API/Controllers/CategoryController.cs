using Microsoft.AspNetCore.Mvc;
using MediatR;
using AppServices.Models;
using AppServices.CategoryActions.Queries;

namespace Contacts.Server.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<Category>>> GetAllCategories()
    {
        var response = await _mediator.Send(new GetAllCategoriesQuery());
        if (response.Count() == 0) return NoContent();
        return Ok(response);
    }

}
