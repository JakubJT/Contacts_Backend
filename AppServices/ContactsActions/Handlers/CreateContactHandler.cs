using MediatR;
using DAL.Repositories;
using AppServices.ContactsActions.Commands;
using AutoMapper;

namespace AppServices.ContactsActions.Handlers;

public class CreateContactHandler : IRequestHandler<CreateContactCommand>
{
    private readonly ContactRepository _contactRepository;
    private readonly IMapper _mapper;

    public CreateContactHandler(ContactRepository contactRepository, IMapper mapper)
    {
        _contactRepository = contactRepository;
        _mapper = mapper;
    }

    public async Task Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        var dalContact = _mapper.Map<DAL.Models.Contact>(request);
        await _contactRepository.CreateContact(dalContact);
    }
}