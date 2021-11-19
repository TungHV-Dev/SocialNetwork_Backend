using AutoMapper;
using SocialNetwork.Data.Dtos.User;
using SocialNetwork.Data.Requests.Authentication;
using SocialNetwork.Data.Responses.Authentication;
using SocialNetwork.Domain.Commands.Authentication;
using SocialNetwork.Domain.Queries.Authentication;

namespace SocialNetwork.Domain.Mapping
{
    public class ModelMapping : Profile
    {
        public ModelMapping()
        {
            CreateMap<FindUserByUserNameResponseDto, GenerateJwtTokenRequest>();
            CreateMap<FindUserByUserNameResponseDto, AuthenticationResponse>();
            CreateMap<RegisterCommand, RegisterRequest>();
            CreateMap<LoginQuery, AuthenticationRequest>();
            CreateMap<AuthenticationResponse, LoginResponse>();
        }
    }
}
