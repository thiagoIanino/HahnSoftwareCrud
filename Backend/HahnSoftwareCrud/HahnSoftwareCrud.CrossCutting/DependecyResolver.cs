using HahnSoftwareCrud.Application;
using HahnSoftwareCrud.Application.Interfaces;
using HahnSoftwareCrud.Domain.Repository;
using HahnSoftwareCrud.Infrastructure.Interfaces;
using HahnSoftwareCrud.Infrastructure.Repositories;
using HahnSoftwareCrud.Infrastructure.Repositories.Database;
using Microsoft.Extensions.DependencyInjection;

namespace HahnSoftwareCrud.CrossCutting
{
    public static class DependecyResolver
    {
        public static void AddDependecyResolver(this IServiceCollection services)
        {
            services.AddScoped<IItemApplication, ItemApplication>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IMysqlRepository, MysqlRepository>();
        }
    }
}