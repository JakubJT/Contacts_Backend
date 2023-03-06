using MediatR;

namespace AppServices.ContactsActions.Commands;

public class DeleteContactCommand : IRequest
{
    public int ContactId { get; set; }
}