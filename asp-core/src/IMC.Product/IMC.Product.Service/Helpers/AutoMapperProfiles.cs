using AutoMapper;
using IMC.Product.Dto;
using IMC.Product.Model;

namespace IMC.Product.Service.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Model.Product, ProductDto>()
            .ForMember(dest => dest.flags, opt => opt.MapFrom(src => src.Flags))
            .ReverseMap();

            CreateMap<Flag, FlagDto>()
            .ReverseMap();
        }
    }
}
