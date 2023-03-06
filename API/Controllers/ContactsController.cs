using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using MediatR;
using AppServices.Models;
using AppServices.ContactsActions.Queries;
using AppServices.ContactsActions.Commands;
using AppServices.SubcategoryActions.Commands;

namespace Contacts.Server.Controllers;

[ApiController]
[Route("[controller]/[action]")]
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
    public async Task<ActionResult<List<ContactBaseInformation>>> GetAllContacts()
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
        return Ok(contactFromDB);
    }

    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> CreateContact(Contact contact)
    {
        var isEmailUnique = await _mediator.Send(new CheckEmailUniquenessQuery() { Email = contact.Email! });
        if (isEmailUnique == false) return Conflict();

        if (contact.Subcategory.IsDefaultSubcategory == false)
        {
            await _mediator.Send(new CreateSubcategoryCommand() { SubcategoryName = contact.Subcategory.Name });
        }

        await _mediator.Send(new CreateContactCommand() { Contact = contact });
        return NoContent();
    }

    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> EditContact(Contact contact)
    {
        var contactFromDB = await _mediator.Send(new GetContactByIdQuery() { ContactId = contact.ContactId });
        if (contactFromDB == null) return NotFound();

        var isEmailUnique = await _mediator.Send(new CheckEmailUniquenessQuery() { Email = contact.Email! });
        if (isEmailUnique == false) return Conflict();

        await _mediator.Send(new EditContactCommand() { Contact = contact });
        return NoContent();
    }

    [HttpDelete]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteContacts(int contactId)
    {
        var contactFromDB = await _mediator.Send(new GetContactByIdQuery() { ContactId = contactId });
        if (contactFromDB == null) return NotFound();

        await _mediator.Send(new DeleteContactCommand() { ContactId = contactId });
        return NoContent();
    }
}
