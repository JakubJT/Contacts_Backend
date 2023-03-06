using AutoMapper;

namespace AppServices.MapperProfiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<DAL.Models.Category, AppServices.Models.Category>();
    }
}