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
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IEmotionRepository, EmotionRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();

            return services;
        }
    }
}
