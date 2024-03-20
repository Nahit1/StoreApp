using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StoreApp.Application.Repositories;
using StoreApp.Domain.Entities;
using StoreApp.Persistance.Context;
using StoreApp.Persistance.Mapping;
using StoreApp.Persistance.Repositories;

namespace StoreApp.Persistance
{
    public static class PersistenceInjection
    {
        public static void AddStoreAppPersistance(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.AddDbContext<StoreAppDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"))
            );

            services
                .AddIdentity<AppUser, IdentityRole>(options =>
                {
                    options.Password.RequiredLength = 3;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<StoreAppDbContext>()
                .AddDefaultTokenProviders();

            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<IBrandsRepository, BrandsRepository>();
        }
    }
}
