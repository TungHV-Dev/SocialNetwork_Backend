using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Service.Implementations;
using SocialNetwork.Service.Interfaces;

namespace SocialNetwork.Service.Mapping
{
    public static class ServicesMapping
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            return services;
        }
    }
}
