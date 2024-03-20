using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Application.Features.Queries.Categories.GetAllCategories
{
    public class GetAllCategoriesDto
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
    }
}
