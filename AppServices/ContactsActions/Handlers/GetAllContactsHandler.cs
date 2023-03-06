using MediatR;
using DAL.Repositories;
using AppServices.Models;
using AppServices.ContactsActions.Queries;

namespace AppServices.ContactsActions.Handlers;

public class GetAllContactsHandler : IRequestHandler<GetAllContactsQuery, List<Contact>>
{
    private readonly ContactRepository _contactRepository;

    public GetAllContactsHandler(ContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task<List<Contact>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
    {
        var contacts = await _contactRepository.GetAllContacts();
        var mappedContacts = new List<AppServices.Models.Contact>();
        foreach (var contact in contacts)
        {
            var mappedContact = new AppServices.Models.Contact()
            {
                ContactId = contact.ContactId,
                Name = contact.Name,
                Surname = contact.Surname,
                PhoneNumber = contact.PhoneNumber,
                CategoryId = contact.CategoryId
            };
            mappedContacts.Add(mappedContact);
        }
        return mappedContacts;
    }
}