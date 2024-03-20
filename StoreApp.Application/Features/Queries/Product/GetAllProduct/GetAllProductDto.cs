using StoreApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public string PictureUrl { get; set; }
        public string Category { get; set; }
        public List<ProductCategoryDto> Categories { get; set; }
    }

    public class ProductCategoryDto
    {
        public string CategoryName { get; set; }
    }
}
