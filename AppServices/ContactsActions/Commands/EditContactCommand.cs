using MediatR;
using AppServices.Models;

namespace AppServices.ContactsActions.Commands;

public class EditContactCommand : IRequest
{
    public Contact? Contact { get; set; }
}