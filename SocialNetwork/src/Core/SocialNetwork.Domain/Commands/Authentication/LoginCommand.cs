using MediatR;
using SocialNetwork.Data.Responses.Authentication;

namespace SocialNetwork.Domain.Commands.Authentication
{
    public class LoginCommand : IRequest<LoginResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
