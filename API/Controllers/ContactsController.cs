using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using MediatR;
using AppServices.Models;

namespace Contacts.Server.Controllers;

[ApiController]
[Route("[controller]/[action]")]
[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
public class ContactsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ContactsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<Contact>>> GetAllContacts()
    {
        return default;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Contact>> GetContact(int contactId)
    {
        return default;
    }

    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> CreateContact(Contact contact)
    {
        return default;
    }

    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> EditContact(Contact contact)
    {
        return default;

    }

    [HttpDelete]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteContacts(int contactId)
    {
        return default;

    }
}
