using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Application.Features.Queries.Brands.GetAllBrands
{
    public class GetAllBrandsDto
    {
        public Guid Id { get; set; }
        public string BrandName { get; set; }
    }
}
