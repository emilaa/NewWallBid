using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WallBid.Data.Persistences;
using WallBid.Infrastructure.Commons.Abstracts;

namespace WallBid.Data
{
    public static class AppDbServiceInjection
    {
        public static IServiceCollection InstallAppDbServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<DbContext, AppDbContext>(config =>
            {
                config.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    option =>
                    {
                        option.MigrationsHistoryTable("Migrations");
                    });
            });

            Type repositoryInterfaceType = typeof(IRepository<>);

            Assembly concrateRepositoryAssembly = typeof(AppDbServiceInjection).Assembly;

            var repositoryPairs = repositoryInterfaceType.Assembly
                .GetTypes()
                .Where(
                m => m.IsInterface &&
                m.GetInterfaces().Any(i => i.IsGenericType &&
                i.GetGenericTypeDefinition() == repositoryInterfaceType))
                .Select(m => new
                {
                    AbstactRepository = m,
                    ConcrateRepository = concrateRepositoryAssembly
                    .GetTypes()
                    .FirstOrDefault(r => r.IsClass && m.IsAssignableFrom(r))
                })
                .Where(m => m.ConcrateRepository != null);

            foreach (var repositoryPair in repositoryPairs)
            {
                services.AddScoped(repositoryPair.AbstactRepository, repositoryPair.ConcrateRepository!);
            }

            return services;
        }
    }
}
