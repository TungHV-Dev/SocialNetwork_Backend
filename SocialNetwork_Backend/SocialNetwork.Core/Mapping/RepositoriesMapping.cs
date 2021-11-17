using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Infrastructure.DatabaseFactory;

namespace SocialNetwork.Core.Mapping
{
    public static class RepositoriesMapping
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDbFactory, DbFactory>();

            return services;
        }
    }
}
