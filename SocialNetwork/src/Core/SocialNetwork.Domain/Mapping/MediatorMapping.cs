using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Domain.Commands.Authentication;
using SocialNetwork.Domain.Commands.Post;
using SocialNetwork.Domain.Queries.Authentication;
using System.Reflection;

namespace SocialNetwork.Domain.Mapping
{
    public static class MediatorMapping
    {
        public static IServiceCollection RegisterMediatR(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.RegisterCommands();
            services.RegisterQueries();

            return services;
        }

        private static IServiceCollection RegisterCommands(this IServiceCollection services)
        {
            // Authentication
            services.AddMediatR(typeof(RegisterCommand).GetTypeInfo().Assembly);

            // Post
            services.AddMediatR(typeof(CreatePostCommand).GetTypeInfo().Assembly);

            return services;
        }

        private static IServiceCollection RegisterQueries(this IServiceCollection services)
        {
            // Authentication
            services.AddMediatR(typeof(LoginQuery).GetTypeInfo().Assembly);

            return services;
        }
    }
}
