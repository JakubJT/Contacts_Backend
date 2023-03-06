using MediatR;
using AutoMapper;
using AppServices.ContactsActions.Queries;
using AppServices.Models;
using DAL.Repositories;

namespace ApplicationServices.Domain.WordActions.Handlers;

public class GetWordByIdHandler : IRequestHandler<GetContactByIdQuery, Contact>
{
    private readonly ContactRepository _contactRepository;
    private readonly IMapper _mapper;

    public GetWordByIdHandler(ContactRepository contactRepository, IMapper mapper)
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