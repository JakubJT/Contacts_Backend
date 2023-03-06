using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using MediatR;
using AppServices.Models;
using AppServices.ContactsActions.Queries;

namespace Contacts.Server.Controllers;

[ApiController]
[Route("[controller]/[action]")]
// [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
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
        var response = await _mediator.Send(new GetAllContactsQuery());
        if (response.Count() == 0) return NoContent();
        return Ok(response);
    }

    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Contact>> GetContactById(int contactId)
    {
        var contactFromDB = await _mediator.Send(new GetContactByIdQuery()
        {
            ContactId = contactId
        });

        if (contactFromDB == null) return NotFound();
        return contactFromDB;
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
