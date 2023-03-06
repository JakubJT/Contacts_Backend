using AutoMapper;

namespace AppServices.MapperProfiles;

public class SubcategoryProfile : Profile
{
    public SubcategoryProfile()
    {
        CreateMap<DAL.Models.Subcategory, AppServices.Models.Subcategory>();
    }
}