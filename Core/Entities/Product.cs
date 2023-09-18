using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Product : BaseEntity
    {
        
        public string Description { get; set; }
        public ProductBrand Brand { get; set; }
        public Guid BrandId { get; set; }

        public ProductType Types { get; set; }
        public Guid TypesId { get; set; }

        public string PictureUrl { get; set; }
    }
}
