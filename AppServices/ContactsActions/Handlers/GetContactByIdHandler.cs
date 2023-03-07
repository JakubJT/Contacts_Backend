using MediatR;
using AutoMapper;
using AppServices.ContactsActions.Queries;
using AppServices.Models;
using DAL.Repositories;

namespace AppServices.ContactActions.Handlers;

public class GetContactByIdHandler : IRequestHandler<GetContactByIdQuery, Contact>
{
    private readonly ContactRepository _contactRepository;
    private readonly IMapper _mapper;

    public GetContactByIdHandler(ContactRepository contactRepository, IMapper mapper)
    {
        _contactRepository = contactRepository;
        _mapper = mapper;
    }
    public async Task<Contact> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
    {
        var dalContact = await _contactRepository.GetContactById(request.ContactId);
        return _mapper.Map<AppServices.Models.Contact>(dalContact);
    }
}