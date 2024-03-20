using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Domain.Entities
{
    public class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }
        public Guid Id { get; set; }
        public string BrandName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
