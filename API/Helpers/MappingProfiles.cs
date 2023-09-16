using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(a => a.Brand, b => b.MapFrom(c => c.Brand.Name))
                .ForMember(a => a.Types, b => b.MapFrom(c => c.Types.Name));
        }
    }
}
