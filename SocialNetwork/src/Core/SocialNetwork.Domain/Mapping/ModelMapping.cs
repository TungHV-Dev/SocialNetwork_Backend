using AutoMapper;
using SocialNetwork.Data.Dtos.Authentication;
using SocialNetwork.Data.Dtos.Comment;
using SocialNetwork.Data.Dtos.Emotion;
using SocialNetwork.Data.Dtos.Friend;
using SocialNetwork.Data.Dtos.Post;
using SocialNetwork.Data.Dtos.User;
using SocialNetwork.Data.Requests.Authentication;
using SocialNetwork.Data.Responses.Authentication;
using SocialNetwork.Domain.Commands.Authentication;
using SocialNetwork.Domain.Commands.Comment;
using SocialNetwork.Domain.Commands.Emotion;
using SocialNetwork.Domain.Commands.Friend;
using SocialNetwork.Domain.Commands.Post;
using SocialNetwork.Domain.Queries.Comment;
using SocialNetwork.Domain.Queries.Emotion;
using SocialNetwork.Domain.Queries.Post;

namespace SocialNetwork.Domain.Mapping
{
    public class ModelMapping : Profile
    {
        public ModelMapping()
        {
            // Authentication
            CreateMap<FindUserByUserNameResponseDto, GenerateJwtTokenRequest>();
            CreateMap<FindUserByUserNameResponseDto, AuthenticationResponse>();
            CreateMap<LoginCommand, AuthenticationRequest>();
            CreateMap<AuthenticationResponse, LoginResponse>();
            CreateMap<RegisterCommand, RegisterRequest>();
            CreateMap<RegisterRequest, RegisterRequestDto>()
                .ForMember(destination => destination.FirstName, source => source.MapFrom(x => x.FirstName))
                .ForMember(destination => destination.LastName, source => source.MapFrom(x => x.LastName))
                .ForMember(destination => destination.Email, source => source.MapFrom(x => x.Email))
                .ForMember(destination => destination.Username, source => source.MapFrom(x => x.Username))
                .ForMember(destination => destination.IsPublicAccount, source => source.MapFrom(x => x.IsPublicAccount));
            CreateMap<ChangePasswordCommand, ChangePasswordRequest>();

            // Post
            CreateMap<CreatePostCommand, CreatePostRequestDto>();
            CreateMap<EditPostCommand, EditPostRequestDto>();
            CreateMap<GetAllPostsOfUserQuery, GetAllPostsOfUserRequestDto>();

            // Emotion
            CreateMap<ExpressEmotionCommand, ExpressEmotionRequestDto>();
            CreateMap<GetEmotionUserQuery, GetEmotionUserRequestDto>();

            // Comment
            CreateMap<CreateCommentCommand, CreateCommentRequestDto>();
            CreateMap<EditCommentCommand, EditCommentRequestDto>();
            CreateMap<GetAllCommentQuery, GetAllCommentRequestDto>();

            // Friend
            CreateMap<ActionForFriendRequestCommand, ActionForFriendRequestDto>();
        }
    }
}
