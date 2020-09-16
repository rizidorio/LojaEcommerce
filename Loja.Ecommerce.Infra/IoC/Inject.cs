using Loja.Ecommerce.Domain.Interfaces;
using Loja.Ecommerce.Infra.Context;
using Loja.Ecommerce.Infra.Repository;
using Loja.Ecommerce.Services.Interfaces;
using Loja.Ecommerce.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Loja.Ecommerce.Infra.IoC
{
    public static class Inject
    {
        public static void InjectService(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddTransient<ContextMongo>();

        }
    }
}
