using MediatR;
using AutoMapper;
using DAL.Repositories;
using AppServices.Models;
using AppServices.ContactsActions.Queries;

namespace AppServices.ContactsActions.Handlers;

public class GetAllContactsHandler : IRequestHandler<GetAllContactsQuery, List<ContactBaseInformation>>
{
    private readonly ContactRepository _contactRepository;
    private readonly IMapper _mapper;

    public GetAllContactsHandler(ContactRepository contactRepository, IMapper mapper)
    {
        _contactRepository = contactRepository;
        _mapper = mapper;
    }

    public async Task<List<ContactBaseInformation>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
    {
        var contacts = await _contactRepository.GetAllContacts();
        return _mapper.Map<List<AppServices.Models.ContactBaseInformation>>(contacts);
    }
}