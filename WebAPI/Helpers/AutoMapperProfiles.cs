using AutoMapper;
using WebAPI.Dtos;
using WebAPI.Models;

namespace WebAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
          CreateMap <City, CityDto>().ReverseMap();
          CreateMap<Property, PropertyListDto>().ForMember(d => d.City, opt => opt.MapFrom(src => src.city.Name)).
          ForMember(d => d.Country, opt => opt.MapFrom(src => src.city.Country)).
          ForMember(d => d.PropertyType, opt => opt.MapFrom(src => src.PropertyType.Name)).
          ForMember(d => d.FurnishingType, opt => opt.MapFrom(src => src.FurnishingType.Name));





        }
    }
}
