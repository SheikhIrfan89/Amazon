using Core.Entities;

namespace API.Dtos
{
    public class ProductDto : BaseEntity
    {
        public string Description { get; set; }
        public string Brand { get; set; }
        public Guid BrandId { get; set; }

        public string Types { get; set; }
        public Guid TypesId { get; set; }
        public string PictureUrl { get; set; }
    }
}
