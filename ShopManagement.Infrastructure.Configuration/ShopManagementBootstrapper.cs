using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application.Contracts.SubProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.SubProductCategory;
using ShopManagement.Infrastructure.EFCore;
using ShopManagement.Infrastructure.EFCore.Repositories;

namespace ShopManagement.Infrastructure.Configuration
{
    public class ShopManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();

            services.AddTransient<ISubProductCategoryApplication, SubProductCategoryApplication>();
            services.AddTransient<ISubProductCategoryRepository, SubProductCategoryRepository>();


            services.AddDbContext<ShopContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
