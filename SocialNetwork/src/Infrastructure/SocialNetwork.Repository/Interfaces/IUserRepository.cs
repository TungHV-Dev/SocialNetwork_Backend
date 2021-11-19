using SocialNetwork.Data.Dtos.Authentication;
using SocialNetwork.Data.Dtos.User;
using System.Threading.Tasks;

namespace SocialNetwork.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<FindUserByUserNameResponseDto> FindUserByUserName(string userName);
        Task<bool> RegisterNewUser(RegisterRequestDto request);
    }
}
