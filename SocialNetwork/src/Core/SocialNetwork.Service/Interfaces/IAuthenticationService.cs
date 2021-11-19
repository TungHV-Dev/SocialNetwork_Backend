using SocialNetwork.Data.Requests.Authentication;
using SocialNetwork.Data.Responses.Authentication;
using System.Threading.Tasks;

namespace SocialNetwork.Service.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
    }
}
