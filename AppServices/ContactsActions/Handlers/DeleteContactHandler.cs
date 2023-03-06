using MediatR;
using DAL.Repositories;
using AppServices.ContactsActions.Commands;

namespace AppServices.ContactsActions.Handlers;

public class DeleteContactHandler : IRequestHandler<DeleteContactCommand>
{
    private readonly ContactRepository _contactRepository;

    public DeleteContactHandler(ContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }
    public async Task Handle(DeleteContactCommand request, CancellationToken cancellationToken)
    {
        await _contactRepository.DeleteContact(request.ContactId);
    }
}