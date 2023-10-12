using AutoMapper;
using Domain;

namespace Infrastructure;
public class MapperProfile:Profile
{
    public MapperProfile()
    {
        CreateMap<AddCategoryDto, Category>().ReverseMap();
        CreateMap<Category, GetCategoryDto>().ReverseMap();

        CreateMap<AddToDoDto, ToDo>().ReverseMap();
        CreateMap<GetToDoDto, ToDo>().ReverseMap();
    }
}
