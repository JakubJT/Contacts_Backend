using MediatR;
using DAL.Repositories;
using AppServices.ContactsActions.Queries;
using AppServices.Models;

namespace ApplicationServices.Domain.WordActions.Handlers;

public class GetWordByIdHandler : IRequestHandler<GetContactByIdQuery, Contact>
{
    private readonly ContactRepository _contactRepository;

    public GetWordByIdHandler(ContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }
    public async Task<Contact> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
    {
        var contact = await _contactRepository.GetContactById(request.ContactId);
        if (contact == null) return default;
        var mappedContact = new AppServices.Models.Contact()
        {
            ContactId = contact.ContactId,
            Name = contact.Name,
            Surname = contact.Surname,
            Password = contact.Password,
            PhoneNumber = contact.PhoneNumber,
            Category = new AppServices.Models.Category()
            {
                Name = contact.Category.Name
            },
            Subcategory = new AppServices.Models.Subcategory()
            {
                Name = contact.Subcategory.Name
            }
        };
        return mappedContact;
    }
}