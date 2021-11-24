using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Domain.Commands.Authentication;
using SocialNetwork.Domain.Commands.Emotion;
using SocialNetwork.Domain.Commands.Post;
using SocialNetwork.Domain.Queries.Emotion;
using SocialNetwork.Domain.Queries.Post;
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
            services.AddMediatR(typeof(LoginCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ChangePasswordCommand).GetTypeInfo().Assembly);

            // Post
            services.AddMediatR(typeof(CreatePostCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(DeletePostCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(EditPostCommand).GetTypeInfo().Assembly);

            // Emotion
            services.AddMediatR(typeof(ExpressEmotionCommand).GetTypeInfo().Assembly);

            return services;
        }

        private static IServiceCollection RegisterQueries(this IServiceCollection services)
        {
            // Post
            services.AddMediatR(typeof(GetAllPostsQuery).GetTypeInfo().Assembly);

            // Emotion
            services.AddMediatR(typeof(GetAllEmotionUserQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetEmotionUserQuery).GetTypeInfo().Assembly);

            return services;
        }
    }
}
