using MediatR;
using DAL.Repositories;
using AppServices.ContactsActions.Queries;

namespace AppServices.ContactsActions.Handlers;

public class CheckEmailUniquenessHandler : IRequestHandler<CheckEmailUniquenessQuery, bool>
{
    private readonly ContactRepository _contactRepository;

    public CheckEmailUniquenessHandler(ContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }
    public async Task<bool> Handle(CheckEmailUniquenessQuery request, CancellationToken cancellationToken)
    {
        bool isEmailExist = await _contactRepository.CheckIfEmailExists(request.Email);
        bool isEmailUnique = !isEmailExist;
        return isEmailUnique;
    }
}