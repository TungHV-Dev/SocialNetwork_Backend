using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Repository.Implementations;
using SocialNetwork.Repository.Interfaces;

namespace SocialNetwork.Domain.Mapping
{
    public static class RepositoriesMapping
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
