using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Domain.Commands.Authentication;
using SocialNetwork.Domain.Commands.Post;
using SocialNetwork.Domain.Queries.Emotion;
using SocialNetwork.Domain.Validations.Authentication;
using SocialNetwork.Domain.Validations.Emotion;
using SocialNetwork.Domain.Validations.Post;

namespace SocialNetwork.Domain.Validations
{
    public static class RegisterValidation
    {
        public static IServiceCollection RegisterModelValidation(this IServiceCollection services)
        {
            services.AddScoped<IValidator<ChangePasswordCommand>, ChangePasswordCommandValidator>();
            services.AddScoped<IValidator<EditPostCommand>, EditPostCommandValidator>();
            services.AddScoped<IValidator<GetEmotionUserQuery>, GetEmotionUserQueryValidator>();

            return services;
        }
    }
}
