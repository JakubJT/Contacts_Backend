using MediatR;
using DAL.Repositories;
using AppServices.ContactsActions.Commands;
using AutoMapper;

namespace AppServices.ContactsActions.Handlers;

public class EditContactHandler : IRequestHandler<EditContactCommand>
{
    private readonly ContactRepository _contactRepository;
    private readonly IMapper _mapper;

    public EditContactHandler(ContactRepository contactRepository, IMapper mapper)
    {
        _contactRepository = contactRepository;
        _mapper = mapper;
    }

    public async Task Handle(EditContactCommand request, CancellationToken cancellationToken)
    {
        var dalContact = _mapper.Map<DAL.Models.Contact>(request.Contact);
        await _contactRepository.EditContact(dalContact);
    }
}