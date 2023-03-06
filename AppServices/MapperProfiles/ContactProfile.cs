using AutoMapper;

namespace AppServices.MapperProfiles;

public class ContactProfile : Profile
{
    public ContactProfile()
    {
        CreateMap<DAL.Models.Contact, AppServices.Models.Contact>();

        CreateMap<DAL.Models.Contact, AppServices.Models.ContactBaseInformation>()
                    .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name));

        CreateMap<AppServices.ContactsActions.Commands.CreateContactCommand, DAL.Models.Contact>();

        CreateMap<AppServices.ContactsActions.Commands.EditContactCommand, DAL.Models.Contact>()
            .ForMember(dest => dest.ContactId, opt => opt.MapFrom(src => src.Contact.ContactId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Contact.Name))
            .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Contact.Surname))
            .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.Contact!.DateOfBirth))
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Contact.CategoryId))
            .ForMember(dest => dest.SubcategoryId, opt => opt.MapFrom(src => src.Contact!.Subcategory.SubcategoryId))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Contact.PhoneNumber))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Contact!.Password))
            .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.Contact!.DateOfBirth))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Contact!.Email));
    }
}