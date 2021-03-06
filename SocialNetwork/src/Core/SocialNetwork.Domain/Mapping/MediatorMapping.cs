using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Domain.Commands.Authentication;
using SocialNetwork.Domain.Commands.Comment;
using SocialNetwork.Domain.Commands.Emotion;
using SocialNetwork.Domain.Commands.Friend;
using SocialNetwork.Domain.Commands.Post;
using SocialNetwork.Domain.Queries.Comment;
using SocialNetwork.Domain.Queries.Emotion;
using SocialNetwork.Domain.Queries.ExportData;
using SocialNetwork.Domain.Queries.Friend;
using SocialNetwork.Domain.Queries.Post;
using SocialNetwork.Domain.Queries.User;
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

            // Comment
            services.AddMediatR(typeof(CreateCommentCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(DeleteCommentCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(EditCommentCommand).GetTypeInfo().Assembly);

            // Friend
            services.AddMediatR(typeof(SendFriendRequestCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CancelFriendRequestCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ActionForFriendRequestCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UnfriendCommand).GetTypeInfo().Assembly);

            return services;
        }

        private static IServiceCollection RegisterQueries(this IServiceCollection services)
        {
            // Post
            services.AddMediatR(typeof(GetAllPostsInTimelineQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetAllPostsOfUserQuery).GetTypeInfo().Assembly);

            // Emotion
            services.AddMediatR(typeof(GetAllEmotionUserQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetEmotionUserQuery).GetTypeInfo().Assembly);

            // Comment
            services.AddMediatR(typeof(GetAllCommentQuery).GetTypeInfo().Assembly);

            // Friend
            services.AddMediatR(typeof(GetAllPendingFriendRequestQuery).GetTypeInfo().Assembly);

            // User
            services.AddMediatR(typeof(GetUserQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetFriendsOfUserQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetAllUserQuery).GetTypeInfo().Assembly);

            // Export Data
            services.AddMediatR(typeof(ExportListUserQuery).GetTypeInfo().Assembly);

            return services;
        }
    }
}
