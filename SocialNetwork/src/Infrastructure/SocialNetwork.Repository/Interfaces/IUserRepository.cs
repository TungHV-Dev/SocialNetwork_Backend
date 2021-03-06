using SocialNetwork.Data.Dtos.Authentication;
using SocialNetwork.Data.Dtos.User;
using SocialNetwork.Data.Responses.Friend;
using SocialNetwork.Data.Responses.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialNetwork.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<FindUserByUserNameResponseDto> FindUserByUserName(string userName);
        Task<FindUserAzureByUserName> FindUserAzureByUserName(string userName);
        Task<bool> RegisterNewUser(RegisterRequestDto request);
        Task<bool> ChangePassword(ChangePasswordRequestDto request);
        Task<IEnumerable<GetFriendOfUserResponse>> GetFriendsOfUser(Guid userID);
        Task<GetUserResponse> GetUserById(Guid userID);
        Task<IEnumerable<GetUserDto>> GetAllUser();
        Task<bool> AddUserAzureAD(AddUserAzureADDto userDto);
    }
}
