using Microsoft.AspNetCore.Mvc;
using MediatR;
using AppServices.Models;
using AppServices.SubcategoryActions.Queries;

namespace Contacts.Server.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class SubcategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public SubcategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<Subcategory>>> GetAllDefaultSubcategories()
    {
        var response = await _mediator.Send(new GetAllDefaultSubcategoriesQuery());
        if (response.Count() == 0) return NoContent();
        return Ok(response);
    }

}
