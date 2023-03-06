using MediatR;
using AppServices.Models;

namespace AppServices.ContactsActions.Queries;

public class GetContactByIdQuery : IRequest<Contact>
{
    public int ContactId { get; set; }
}