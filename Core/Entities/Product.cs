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
        public Brand Brand { get; set; }
        public Guid BrandId { get; set; }

        public Types Types { get; set; }
        public Guid TypeId { get; set; }
    }
}
