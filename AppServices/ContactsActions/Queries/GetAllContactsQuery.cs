using MediatR;
using AppServices.Models;

namespace AppServices.ContactsActions.Queries;

public class GetAllContactsQuery : IRequest<List<Contact>>
{
}