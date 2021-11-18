using SocialNetwork.Common.Models;

namespace SocialNetwork.Common.Authorization
{
    public class SecurityDataProvider : ISecurityDataProvider
    {
        #region Fields
        private UserData UserData { get; set; } = new UserData();
        #endregion

        #region Public Functions
        public void SetUserData(UserData userData)
        {
            UserData = userData;
        }

        public UserData GetUserData()
        {
            return UserData;
        }

        #endregion
    }
}
