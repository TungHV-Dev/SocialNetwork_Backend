using SocialNetwork.Data.Dtos.User;
using SocialNetwork.Data.Requests.Authentication;
using System.Threading.Tasks;

namespace SocialNetwork.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<FindUserByUserNameResponseDto> FindUserByUserName(string userName);
        Task<bool> RegisterNewUser(RegisterRequest request);
    }
}
