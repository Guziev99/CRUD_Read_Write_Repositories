using EStore_Application.Repositories;
using EStore_Application.Repositories.CategoryRepos;
using EStore_Application.Repositories.CustomerRepos;
using EStore_Application.Repositories.OrderRepos;
using EStore_Application.Repositories.ProductRepos;
using EStore_Persistence.DBContexts;
using EStore_Persistence.Repositories;
using EStore_Persistence.Repositories.CategoryRepo;
using EStore_Persistence.Repositories.CustomerRepo;
using EStore_Persistence.Repositories.OrderRepo;
using EStore_Persistence.Repositories.ProductRepo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore_Persistence
{
    public static class RegisterServices
    {
        public static void AddPersistenceRegister (this IServiceCollection services)
        {
            services.AddDbContext<EStore_DbContext>(options =>
            {
                ConfigurationBuilder builderConfig = new ConfigurationBuilder();
                var builder = builderConfig.AddJsonFile("appsettings.json").Build();
                options.UseSqlServer(builder.GetConnectionString("default")).UseLazyLoadingProxies();
            });



            // Register Repositories
            //services.AddScoped<IProductRepository, ProductRepository>();
            //services.AddScoped<ICategoryRepository, CategoryRepository>();


            // All Read Repos
            services.AddScoped<IReadProductRepository, ReadProductRepository>();
            services.AddScoped<IReadOrderRepository, ReadOrderRepository>();
            services.AddScoped<IReadCategoryRepository, ReadCategoryRepository>();
            services.AddScoped<ICustomerReadRepository, ReadCustomerRepository>();


            // All Write Repos
            
            services.AddScoped<IWriteCategoryRepository, WriteCategoyrRepository>();
            services.AddScoped<IWriteProductRepository, WriteProductRepository>();
            services.AddScoped<IWriteOrderRepository, WriteOrderRepository>();  
            services.AddScoped<IWriteCustomerRepository, WriteCustomerRepository>();


            
        }

    }
}
