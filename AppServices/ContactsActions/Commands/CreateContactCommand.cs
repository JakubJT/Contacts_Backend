using MediatR;
using AppServices.Models;

namespace AppServices.ContactsActions.Commands;

public class CreateContactCommand : IRequest
{
    public Contact? Contact { get; set; }
}