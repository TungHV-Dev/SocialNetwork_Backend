using AutoMapper;
using SocialNetwork.Data.Dtos.Authentication;
using SocialNetwork.Data.Dtos.Post;
using SocialNetwork.Data.Dtos.User;
using SocialNetwork.Data.Requests.Authentication;
using SocialNetwork.Data.Responses.Authentication;
using SocialNetwork.Domain.Commands.Authentication;
using SocialNetwork.Domain.Commands.Post;
using SocialNetwork.Domain.Queries.Authentication;

namespace SocialNetwork.Domain.Mapping
{
    public class ModelMapping : Profile
    {
        public ModelMapping()
        {
            CreateMap<FindUserByUserNameResponseDto, GenerateJwtTokenRequest>();
            CreateMap<FindUserByUserNameResponseDto, AuthenticationResponse>();
            CreateMap<LoginQuery, AuthenticationRequest>();
            CreateMap<AuthenticationResponse, LoginResponse>();
            CreateMap<RegisterCommand, RegisterRequest>();
            CreateMap<RegisterRequest, RegisterRequestDto>()
                .ForMember(destination => destination.FirstName, source => source.MapFrom(x => x.FirstName))
                .ForMember(destination => destination.LastName, source => source.MapFrom(x => x.LastName))
                .ForMember(destination => destination.Email, source => source.MapFrom(x => x.Email))
                .ForMember(destination => destination.Username, source => source.MapFrom(x => x.Username))
                .ForMember(destination => destination.IsPublicAccount, source => source.MapFrom(x => x.IsPublicAccount));

            CreateMap<CreatePostCommand, CreatePostRequestDto>();
        }
    }
}
