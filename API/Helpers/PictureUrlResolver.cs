using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class PictureUrlResolver : IValueResolver<Product, ProductDto, String>
    {
        private readonly IConfiguration _configuration;

        public PictureUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.PictureUrl))
                return _configuration["ApiUrl"]+ source.PictureUrl;
            return "No image Found!!";
        }
    }
}
