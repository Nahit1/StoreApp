using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StoreApp.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Application
{
    public static class ApplicationInjection
    {
        public static void AddStoreAppApplication(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        }
    }
}
