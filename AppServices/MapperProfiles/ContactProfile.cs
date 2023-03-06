using AutoMapper;

namespace AppServices.MapperProfiles;

public class ContactProfile : Profile
{
    public ContactProfile()
    {
        CreateMap<DAL.Models.Contact, AppServices.Models.Contact>();

        CreateMap<AppServices.ContactsActions.Commands.CreateContactCommand, DAL.Models.Contact>();

        CreateMap<AppServices.ContactsActions.Commands.EditContactCommand, DAL.Models.Contact>();
    }
}