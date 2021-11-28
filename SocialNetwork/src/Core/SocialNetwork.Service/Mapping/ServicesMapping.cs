using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Common.Authorization;
using SocialNetwork.Service.Implementations;
using SocialNetwork.Service.Interfaces;

namespace SocialNetwork.Service.Mapping
{
    public static class ServicesMapping
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ISecurityDataProvider, SecurityDataProvider>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
