using MediatR;
using AppServices.Models;

namespace AppServices.ContactsActions.Queries;

public class CheckEmailUniquenessQuery : IRequest<bool>
{
    public string Email { get; set; }
}