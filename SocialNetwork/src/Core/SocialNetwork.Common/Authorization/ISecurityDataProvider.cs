using SocialNetwork.Common.Models;

namespace SocialNetwork.Common.Authorization
{
    public interface ISecurityDataProvider
    {
        void SetUserData(UserData userData);
        UserData GetUserData();
    }
}
