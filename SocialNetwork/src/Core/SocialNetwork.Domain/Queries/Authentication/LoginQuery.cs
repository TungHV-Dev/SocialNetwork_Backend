using MediatR;
using SocialNetwork.Data.Responses.Authentication;

namespace SocialNetwork.Domain.Queries.Authentication
{
    public class LoginQuery : IRequest<LoginResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
