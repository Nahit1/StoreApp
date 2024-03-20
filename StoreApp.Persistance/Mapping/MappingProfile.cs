using AutoMapper;
using StoreApp.Application.Features.Queries.Brands.GetAllBrands;
using StoreApp.Application.Features.Queries.Categories.GetAllCategories;
using StoreApp.Application.Features.Queries.Product.GetAllProduct;
using StoreApp.Domain.Entities;

namespace StoreApp.Persistance.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, GetAllProductDto>();
            CreateMap<Category, ProductCategoryDto>();
            CreateMap<Category, GetAllCategoriesDto>();
            CreateMap<Brand, GetAllBrandsDto>();
        }
    }
}
