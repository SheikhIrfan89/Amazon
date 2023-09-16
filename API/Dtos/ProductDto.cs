using Core.Entities;

namespace API.Dtos
{
    public class ProductDto : BaseEntity
    {
        public string Description { get; set; }
        public string BrandName { get; set; }
        public Guid BrandId { get; set; }

        public string TypeName { get; set; }
        public Guid TypesId { get; set; }
    }
}
